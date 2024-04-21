using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using UnityEngine;

public static class DbConnectionLocal {

    private static readonly string baseFolder = "TerritorioAventuras_Data/";
    //private static readonly string databaseSql = baseFolder + "sql.dll";
    private static readonly string database = "URI=file:" + baseFolder + "sqldb.dll";

    private static bool isFristLoad = true;

    public static bool Write(string query)
    {
        PreloadDataBase();
        return QueryWrite(query);
    }

    public static T Read<T>(string query)
    {
        PreloadDataBase();
        return QueryRead<T>(query, true);
    }

    public static T Find<T>(string query)
    {
        PreloadDataBase();
        return QueryRead<T>(query, false);
    }

    private static void PreloadDataBase()
    {
        if (isFristLoad)
        {
            QueryWrite(ReadDatabaseQuery());
            isFristLoad = false;
        }
    }

    private static T QueryRead<T>(string query, bool isList)
    {
        try
        {
            using (var connection = new SqliteConnection(database))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        var rows = new object();
                        if (isList)
                        {
                            rows = ConvertListToString(reader);
                        }
                        else
                        {
                            rows = ConvertOneToString(reader);
                        }
                        var json = JsonConvert.SerializeObject(rows);
                        var result = JsonConvert.DeserializeObject<T>(json);

                        connection.Close();
                        return result;
                    }
                }
            }
        }catch (Exception ex) {
            Debug.Log(ex.ToString());
            return default(T);
        }
    }

    private static bool QueryWrite(string query)
    {
        try
        {
            using (var connection = new SqliteConnection(database))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    int recordsAffected = command.ExecuteNonQuery();

                    connection.Close();
                    return recordsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return false;
        }
    }

    private static List<Dictionary<string, object>> ConvertListToString(IDataReader reader)
    {
        var columns = new List<string>();
        var rows = new List<Dictionary<string, object>>();

        for (var i = 0; i < reader.FieldCount; i++)
        {
            columns.Add(reader.GetName(i));
        }
        while (reader.Read())
        {
            rows.Add(columns.ToDictionary(column => column, column => reader[column]));
        }
        return rows;
    }

    private static Dictionary<string, object> ConvertOneToString(IDataReader reader)
    {
        var columns = new List<string>();
        var rows = new Dictionary<string, object>();

        for (var i = 0; i < reader.FieldCount; i++)
        {
            columns.Add(reader.GetName(i));
        }
        while (reader.Read())
        {
            rows = columns.ToDictionary(column => column, column => reader[column]);
        }
        return rows;
    }

    /*private static string ReadDatabaseFile()
    {
        StreamReader inp_stm = new StreamReader(databaseSql);
        StringBuilder stringBuilder = new StringBuilder();
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            stringBuilder.AppendLine(inp_ln);
        }
        inp_stm.Close();
        string reader = stringBuilder.ToString();

        var base64EncodedBytes = Convert.FromBase64String(reader);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }*/

    private static string ReadDatabaseQuery()
    {
        bool folderExists = Directory.Exists(baseFolder);
        if (!folderExists) Directory.CreateDirectory(baseFolder);

        string reader = "Q1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2F2YXRhcicgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidhdmF0YXInIFRFWFQgIE5PVCBOVUxMLAonaWRfZ2VuZGVyJyBpbnQgTk9UIE5VTEwsCidyZWdpc3Rlcl9kYXRlJyB0aW1lc3RhbXAgTlVMTCBERUZBVUxUIENVUlJFTlRfVElNRVNUQU1QLApGT1JFSUdOIEtFWSAoJ2lkX2dlbmRlcicpIFJFRkVSRU5DRVMgJ2dlbmRlcicgKCdpZCcpCik7CgpDUkVBVEUgVEFCTEUgSUYgTk9UIEVYSVNUUyAnZW1vdGljb24nICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonZW1vdGljb24nIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2dhbWVfc3RhdGUnICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonaWRfdXNlcicgaW50IE5PVCBOVUxMLAonaWRfYXZhdGFyJyBpbnQgTk9UIE5VTEwsCidpZF9sZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nIGludCBOT1QgTlVMTCwKJ3JlZ2lzdGVyX2RhdGUnIHRpbWVzdGFtcCBOVUxMIERFRkFVTFQgQ1VSUkVOVF9USU1FU1RBTVAsCkZPUkVJR04gS0VZICgnaWRfYXZhdGFyJykgUkVGRVJFTkNFUyAnYXZhdGFyJyAoJ2lkJyksCkZPUkVJR04gS0VZICgnaWRfbGV2ZWxfY2hhbGxlbmdlX2Rlc2NyaXB0aW9uJykgUkVGRVJFTkNFUyAnbGV2ZWxfY2hhbGxlbmdlX2Rlc2NyaXB0aW9uJyAoJ2lkJyksCkZPUkVJR04gS0VZICgnaWRfdXNlcicpIFJFRkVSRU5DRVMgJ3VzZXInICgnaWQnKQopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2dlbmRlcicgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidnZW5kZXInIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2xldmVsX2NoYWxsZW5nZV9hdHRlbXB0JyAoCidpZCcgSU5URUdFUiBQUklNQVJZIEtFWSBBVVRPSU5DUkVNRU5UIE5PVCBOVUxMICwKJ2lkX2NoYWxsZW5nZV9kZXNjcmlwdGlvbicgaW50IE5PVCBOVUxMLAonYXR0ZW1wdHMnIFRFWFQgIE5PVCBOVUxMLAonZ2FtZV90aW1lJyBURVhUICBOT1QgTlVMTCwKJ3JlZ2lzdGVyX2RhdGUnIHRpbWVzdGFtcCBOVUxMIERFRkFVTFQgQ1VSUkVOVF9USU1FU1RBTVAsCkZPUkVJR04gS0VZICgnaWRfY2hhbGxlbmdlX2Rlc2NyaXB0aW9uJykgUkVGRVJFTkNFUyAnbGV2ZWxfY2hhbGxlbmdlX2Rlc2NyaXB0aW9uJyAoJ2lkJykKKTsKCkNSRUFURSBUQUJMRSBJRiBOT1QgRVhJU1RTICdsZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonbmFtZV9sZXZlbCcgVEVYVCAgTk9UIE5VTEwsCiduYW1lX2JhZGdlJyBURVhUICBOT1QgTlVMTCwKJ2NvaW5zJyBURVhUICBOT1QgTlVMTCwKJ2lkX2Vtb3RpY29uJyBpbnQgTk9UIE5VTEwsCidyZWdpc3Rlcl9kYXRlJyB0aW1lc3RhbXAgTlVMTCBERUZBVUxUIENVUlJFTlRfVElNRVNUQU1QLApGT1JFSUdOIEtFWSAoJ2lkX2Vtb3RpY29uJykgUkVGRVJFTkNFUyAnZW1vdGljb24nICgnaWQnKQopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ3JvbCcgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidyb2wnIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ3VzZXInICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonbmFtZScgVEVYVCAgTk9UIE5VTEwsCidhZ2UnIFRFWFQgIE5PVCBOVUxMLAonZW1haWwnIFRFWFQgIE5PVCBOVUxMLAonc2Nob29sJyBURVhUICBOT1QgTlVMTCwKJ3VzZXInIFRFWFQgIE5PVCBOVUxMIFVOSVFVRSwKJ3Bhc3N3b3JkJyBURVhUICBOT1QgTlVMTCwKJ2lkX2dlbmRlcicgaW50IE5PVCBOVUxMLAonaWRfcm9sJyBpbnQgTk9UIE5VTEwsCidyZWdpc3Rlcl9kYXRlJyB0aW1lc3RhbXAgTlVMTCBERUZBVUxUIENVUlJFTlRfVElNRVNUQU1QLApGT1JFSUdOIEtFWSAoJ2lkX2dlbmRlcicpIFJFRkVSRU5DRVMgJ2dlbmRlcicgKCdpZCcpLApGT1JFSUdOIEtFWSAoJ2lkX3JvbCcpIFJFRkVSRU5DRVMgJ3JvbCcgKCdpZCcpCik7CgpDUkVBVEUgSU5ERVggSUYgTk9UIEVYSVNUUyAnYXZhdGFyX0ZLX2F2YXRhcl9nZW5kZXInIE9OICdhdmF0YXInICgnaWRfZ2VuZGVyJyk7CkNSRUFURSBJTkRFWCBJRiBOT1QgRVhJU1RTICdnYW1lX3N0YXRlX0ZLX2dhbWVfc3RhdGVfdXNlcicgT04gJ2dhbWVfc3RhdGUnICgnaWRfdXNlcicpOwpDUkVBVEUgSU5ERVggSUYgTk9UIEVYSVNUUyAnZ2FtZV9zdGF0ZV9GS19nYW1lX3N0YXRlX2F2YXRhcicgT04gJ2dhbWVfc3RhdGUnICgnaWRfYXZhdGFyJyk7CkNSRUFURSBJTkRFWCBJRiBOT1QgRVhJU1RTICdnYW1lX3N0YXRlX0ZLX2dhbWVfc3RhdGVfbGV2ZWxfY2hhbGxlbmdlX2Rlc2NyaXB0aW9uJyBPTiAnZ2FtZV9zdGF0ZScgKCdpZF9sZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ2xldmVsX2NoYWxsZW5nZV9hdHRlbXB0X0ZLX2xldmVsX2NoYWxsZW5nZV9hdHRlbXB0c19sZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nIE9OICdsZXZlbF9jaGFsbGVuZ2VfYXR0ZW1wdCcgKCdpZF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ2xldmVsX2NoYWxsZW5nZV9kZXNjcmlwdGlvbl9GS19sZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb25fZW1vdGljb24nIE9OICdsZXZlbF9jaGFsbGVuZ2VfZGVzY3JpcHRpb24nICgnaWRfZW1vdGljb24nKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ3VzZXJfRktfdXNlcl9yb2wnIE9OICd1c2VyJyAoJ2lkX3JvbCcpOwpDUkVBVEUgSU5ERVggSUYgTk9UIEVYSVNUUyAndXNlcl9GS191c2VyX2dlbmRlcicgT04gJ3VzZXInICgnaWRfZ2VuZGVyJyk7CgoKSU5TRVJUIE9SIElHTk9SRSBJTlRPICdlbW90aWNvbicgKCdpZCcsICdlbW90aWNvbicsICdyZWdpc3Rlcl9kYXRlJykgVkFMVUVTCigxLCAnRmVsaXonLCAnMjAyMy0xMC0wNSAxOTo0OTo0MCcpLAooMiwgJ1RyaXN0ZScsICcyMDIzLTEwLTA1IDE5OjQ5OjQwJyksCigzLCAnSW5kaWZlcmVudGUnLCAnMjAyMy0xMC0wNSAxOTo0OTo0MCcpOwoKSU5TRVJUIE9SIElHTk9SRSBJTlRPICdnZW5kZXInICgnaWQnLCAnZ2VuZGVyJywgJ3JlZ2lzdGVyX2RhdGUnKSBWQUxVRVMKKDEsICdOacOxbycsICcyMDIzLTEwLTA1IDE5OjUxOjA0JyksCigyLCAnTmnDsWEnLCAnMjAyMy0xMC0wNSAxOTo1MTowNCcpOwoKSU5TRVJUIE9SIElHTk9SRSBJTlRPICdyb2wnICgnaWQnLCAncm9sJywgJ3JlZ2lzdGVyX2RhdGUnKSBWQUxVRVMKKDEsICdFc3R1ZGlhbnRlJywgJzIwMjMtMTAtMDUgMTk6NTU6MTYnKSwKKDIsICdQcm9mZXNvcicsICcyMDIzLTEwLTA1IDE5OjU1OjE2JyksCigzLCAnQWRtaW5pc3RyYWRvcicsICcyMDIzLTEwLTA1IDE5OjU1OjE2Jyk7CgpJTlNFUlQgT1IgSUdOT1JFIElOVE8gJ2F2YXRhcicgKCdpZCcsICdhdmF0YXInLCAnaWRfZ2VuZGVyJywgJ3JlZ2lzdGVyX2RhdGUnKSBWQUxVRVMKKDEsICdCaW9sb2dvJywgMSwgJzIwMjMtMTAtMDUgMjA6MTk6MDYnKSwKKDIsICdCaW9sb2dvJywgMiwgJzIwMjMtMTAtMDUgMjA6MTk6MTMnKSwKKDMsICdGb3RvZ3JhZm8nLCAxLCAnMjAyMy0xMC0wNSAyMDoyMDoyMScpLAooNCwgJ0ZvdG9ncmFmbycsIDIsICcyMDIzLTEwLTA1IDIwOjIwOjMwJyksCig1LCAnRGVwb3J0aXN0YScsIDEsICcyMDIzLTEwLTA1IDIwOjIwOjM5JyksCig2LCAnRGVwb3J0aXN0YScsIDIsICcyMDIzLTEwLTA1IDIwOjIwOjQ1Jyk7";
        var base64EncodedBytes = Convert.FromBase64String(reader);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

}
