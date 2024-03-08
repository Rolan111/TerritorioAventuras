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
    private static readonly string databaseSql = baseFolder + "sql.dll";
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
        return QueryRead<T>(query);
    }

    private static void PreloadDataBase()
    {
        if (isFristLoad)
        {
            QueryWrite(ReadDatabaseFile());
            isFristLoad = false;
        }
    }

    private static T QueryRead<T>(string query)
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
                        var rows = ConvertToString(reader);
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

    private static List<Dictionary<string, object>> ConvertToString(IDataReader reader)
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

    private static string ReadDatabaseFile()
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
    }

}
