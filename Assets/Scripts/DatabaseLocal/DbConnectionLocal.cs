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

    public static int Write(string query)
    {
        PreloadDataBase();
        return QueryWrite(query, true);
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
            QueryWrite(ReadDatabaseQuery(), false);
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

    private static int QueryWrite(string query, bool getLasId)
    {
        try
        {
            using (var connection = new SqliteConnection(database))
            {
                int recordsAffected = 0;
                int lastId = 0;

                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    recordsAffected = command.ExecuteNonQuery();   
                }

                if (getLasId)
                {
                    using (var command = connection.CreateCommand())
                    {
                        if (recordsAffected > 0)
                        {
                            command.CommandText = @"SELECT last_insert_rowid()";
                            lastId = Int32.Parse(command.ExecuteScalar().ToString());
                        }
                    }
                }
                connection.Close();
                return lastId;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return 0;
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

        if (rows.Count > 0)
        {
            return rows;
        }
        return null;
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

        if(rows.Count > 0)
        {
            return rows;
        }
        return null;
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

        string reader = "Q1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2F2YXRhcicgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidhdmF0YXInIFRFWFQgIE5PVCBOVUxMLAonaWRfZ2VuZGVyJyBpbnQgTk9UIE5VTEwsCidyZWdpc3Rlcl9kYXRlJyB0aW1lc3RhbXAgTlVMTCBERUZBVUxUIENVUlJFTlRfVElNRVNUQU1QLApGT1JFSUdOIEtFWSAoJ2lkX2dlbmRlcicpIFJFRkVSRU5DRVMgJ2dlbmRlcicgKCdpZCcpCik7CgpDUkVBVEUgVEFCTEUgSUYgTk9UIEVYSVNUUyAnZW1vdGljb24nICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonZW1vdGljb24nIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2dhbWVfc3RhdGUnICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonaWRfdXNlcicgaW50IE5PVCBOVUxMLAonaWRfYXZhdGFyJyBpbnQgTk9UIE5VTEwsCidpZF9sZXZlbF9kZXNjcmlwdGlvbicgaW50IE5PVCBOVUxMLAonYXR0ZW1wdHMnIFRFWFQgIE5PVCBOVUxMLAonY29pbnMnIFRFWFQgIE5PVCBOVUxMLAonZ2FtZV90aW1lJyBURVhUICBOT1QgTlVMTCwKJ3Rvb2xzJyBpbnQgTk9UIE5VTEwsCidhY3R1YWxfZ2FtZScgaW50IE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUCwKRk9SRUlHTiBLRVkgKCdpZF9hdmF0YXInKSBSRUZFUkVOQ0VTICdhdmF0YXInICgnaWQnKSwKRk9SRUlHTiBLRVkgKCdpZF9sZXZlbF9kZXNjcmlwdGlvbicpIFJFRkVSRU5DRVMgJ2xldmVsX2Rlc2NyaXB0aW9uJyAoJ2lkJyksCkZPUkVJR04gS0VZICgnaWRfdXNlcicpIFJFRkVSRU5DRVMgJ3VzZXInICgnaWQnKQopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2dlbmRlcicgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidnZW5kZXInIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ2xldmVsX2Rlc2NyaXB0aW9uJyAoCidpZCcgSU5URUdFUiBQUklNQVJZIEtFWSBBVVRPSU5DUkVNRU5UIE5PVCBOVUxMICwKJ25hbWVfbGV2ZWwnIFRFWFQgIE5PVCBOVUxMLAonbmFtZV9iYWRnZScgVEVYVCAgTk9UIE5VTEwsCidjb2lucycgVEVYVCAgTk9UIE5VTEwsCidzY2VuZV9uYW1lJyBURVhUIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ3JvbCcgKAonaWQnIElOVEVHRVIgUFJJTUFSWSBLRVkgQVVUT0lOQ1JFTUVOVCBOT1QgTlVMTCAsCidyb2wnIFRFWFQgIE5PVCBOVUxMLAoncmVnaXN0ZXJfZGF0ZScgdGltZXN0YW1wIE5VTEwgREVGQVVMVCBDVVJSRU5UX1RJTUVTVEFNUAopOwoKQ1JFQVRFIFRBQkxFIElGIE5PVCBFWElTVFMgJ3VzZXInICgKJ2lkJyBJTlRFR0VSIFBSSU1BUlkgS0VZIEFVVE9JTkNSRU1FTlQgTk9UIE5VTEwgLAonbmFtZScgVEVYVCAgTk9UIE5VTEwsCidhZ2UnIFRFWFQgIE5PVCBOVUxMLAonZW1haWwnIFRFWFQgIE5PVCBOVUxMLAonc2Nob29sJyBURVhUICBOT1QgTlVMTCwKJ3VzZXInIFRFWFQgIE5PVCBOVUxMIFVOSVFVRSwKJ3Bhc3N3b3JkJyBURVhUICBOT1QgTlVMTCwKJ2lkX2dlbmRlcicgaW50IE5PVCBOVUxMLAonaWRfcm9sJyBpbnQgTk9UIE5VTEwsCidyZWdpc3Rlcl9kYXRlJyB0aW1lc3RhbXAgTlVMTCBERUZBVUxUIENVUlJFTlRfVElNRVNUQU1QLApGT1JFSUdOIEtFWSAoJ2lkX2dlbmRlcicpIFJFRkVSRU5DRVMgJ2dlbmRlcicgKCdpZCcpLApGT1JFSUdOIEtFWSAoJ2lkX3JvbCcpIFJFRkVSRU5DRVMgJ3JvbCcgKCdpZCcpCik7CgpDUkVBVEUgSU5ERVggSUYgTk9UIEVYSVNUUyAnYXZhdGFyX0ZLX2F2YXRhcl9nZW5kZXInIE9OICdhdmF0YXInICgnaWRfZ2VuZGVyJyk7CkNSRUFURSBJTkRFWCBJRiBOT1QgRVhJU1RTICdnYW1lX3N0YXRlX0ZLX2dhbWVfc3RhdGVfYXZhdGFyJyBPTiAnZ2FtZV9zdGF0ZScgKCdpZF9hdmF0YXInKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ2dhbWVfc3RhdGVfRktfZ2FtZV9zdGF0ZV9sZXZlbF9kZXNjcmlwdGlvbicgT04gJ2dhbWVfc3RhdGUnICgnaWRfbGV2ZWxfZGVzY3JpcHRpb24nKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ2dhbWVfc3RhdGVfRktfZ2FtZV9zdGF0ZV91c2VyJyBPTiAnZ2FtZV9zdGF0ZScgKCdpZF91c2VyJyk7CkNSRUFURSBJTkRFWCBJRiBOT1QgRVhJU1RTICd1c2VyX0ZLX3VzZXJfcm9sJyBPTiAndXNlcicgKCdpZF9yb2wnKTsKQ1JFQVRFIElOREVYIElGIE5PVCBFWElTVFMgJ3VzZXJfRktfdXNlcl9nZW5kZXInIE9OICd1c2VyJyAoJ2lkX2dlbmRlcicpOwoKCklOU0VSVCBPUiBJR05PUkUgSU5UTyAnZW1vdGljb24nICgnaWQnLCAnZW1vdGljb24nLCAncmVnaXN0ZXJfZGF0ZScpIFZBTFVFUwooMSwgJ0ZlbGl6JywgJzIwMjMtMTAtMDUgMTk6NDk6NDAnKSwKKDIsICdUcmlzdGUnLCAnMjAyMy0xMC0wNSAxOTo0OTo0MCcpLAooMywgJ0luZGlmZXJlbnRlJywgJzIwMjMtMTAtMDUgMTk6NDk6NDAnKTsKCklOU0VSVCBPUiBJR05PUkUgSU5UTyAnZ2VuZGVyJyAoJ2lkJywgJ2dlbmRlcicsICdyZWdpc3Rlcl9kYXRlJykgVkFMVUVTCigxLCAnTWFzY3VsaW5vJywgJzIwMjMtMTAtMDUgMTk6NTE6MDQnKSwKKDIsICdGZW1lbmlubycsICcyMDIzLTEwLTA1IDE5OjUxOjA0JyksCigzLCAnT3RybycsICcyMDIzLTEwLTA1IDE5OjUxOjA0Jyk7CgpJTlNFUlQgT1IgSUdOT1JFIElOVE8gJ3JvbCcgKCdpZCcsICdyb2wnLCAncmVnaXN0ZXJfZGF0ZScpIFZBTFVFUwooMSwgJ0VzdHVkaWFudGUnLCAnMjAyMy0xMC0wNSAxOTo1NToxNicpLAooMiwgJ1Byb2Zlc29yJywgJzIwMjMtMTAtMDUgMTk6NTU6MTYnKSwKKDMsICdBZG1pbmlzdHJhZG9yJywgJzIwMjMtMTAtMDUgMTk6NTU6MTYnKTsKCklOU0VSVCBPUiBJR05PUkUgSU5UTyAnYXZhdGFyJyAoJ2lkJywgJ2F2YXRhcicsICdpZF9nZW5kZXInLCAncmVnaXN0ZXJfZGF0ZScpIFZBTFVFUwooMSwgJ0Jpb2xvZ28nLCAxLCAnMjAyMy0xMC0wNSAyMDoxOTowNicpLAooMiwgJ0Jpb2xvZ28nLCAyLCAnMjAyMy0xMC0wNSAyMDoxOToxMycpLAooMywgJ0ZvdG9ncmFmbycsIDEsICcyMDIzLTEwLTA1IDIwOjIwOjIxJyksCig0LCAnRm90b2dyYWZvJywgMiwgJzIwMjMtMTAtMDUgMjA6MjA6MzAnKSwKKDUsICdEZXBvcnRpc3RhJywgMSwgJzIwMjMtMTAtMDUgMjA6MjA6MzknKSwKKDYsICdEZXBvcnRpc3RhJywgMiwgJzIwMjMtMTAtMDUgMjA6MjA6NDUnKTsKCklOU0VSVCBPUiBJR05PUkUgSU5UTyAnbGV2ZWxfZGVzY3JpcHRpb24nICgnaWQnLCAnbmFtZV9sZXZlbCcsICduYW1lX2JhZGdlJywgJ2NvaW5zJywgJ3NjZW5lX25hbWUnLCAncmVnaXN0ZXJfZGF0ZScpIFZBTFVFUyAKKDEsICdBZ3VhJywgJ01hY2l6bycsICc0MCcsICczIE11bmRvIDFBZ3VhJywgJzIwMjMtMTAtMDUgMjA6MjA6NDUnKSwKKDIsICdDaXVkYWQnLCAnQ2VudHJvJywgJzQwJywgJzQgTXVuZG8gMkNlbnRybycsICcyMDIzLTEwLTA1IDIwOjIwOjQ1JyksCigzLCAnTWFyJywgJ1BhY8OtZmljbycsICc0MCcsICc1IE11bmRvIDNQYWPDrWZpY29Gb2xjbG9yJywgJzIwMjMtMTAtMDUgMjA6MjA6NDUnKSwKKDQsICdTb2wnLCAnTm9ydGUnLCAnNDAnLCAnNSBNdW5kbyA0Tm9ydGUnLCAnMjAyMy0xMC0wNSAyMDoyMDo0NScpLAooNSwgJ0FpcmUnLCAnT3JpZW50ZScsICc0MCcsICc1IE11bmRvIDVPcmllbnRlVGVjbm9sb2fDrWEnLCAnMjAyMy0xMC0wNSAyMDoyMDo0NScpLAooNiwgJ1NlbHZhJywgJ1BpYW1vbnRlJywgJzQwJywgJzYgTXVuZG8gNiAtIEV0bmlhc1BpYW1vbnRlJywgJzIwMjMtMTAtMDUgMjA6MjA6NDUnKSwKKDcsICdNb250YcOxYScsICdTdXInLCAnNDAnLCAnNyBNdW5kbyA3U3VyJywgJzIwMjMtMTAtMDUgMjA6MjA6NDUnKTsKCklOU0VSVCBPUiBJR05PUkUgSU5UTyAndXNlcicgKCdpZCcsICduYW1lJywgJ2FnZScsICdlbWFpbCcsICdzY2hvb2wnLCAndXNlcicsICdwYXNzd29yZCcsICdpZF9nZW5kZXInLCAnaWRfcm9sJywgJ3JlZ2lzdGVyX2RhdGUnKSBWQUxVRVMgCigxLCAnRG9jZW50ZScsICcwJywgJ2RvY2VudGUnLCAndGVycml0b3JpbycsICdEb2NlbnRlJywgJ3RlcnJpdG9yaW8nLCAzLCAyLCAnMjAyMy0xMC0wNSAyMDoyMDo0NScpOw==";
        var base64EncodedBytes = Convert.FromBase64String(reader);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

}
