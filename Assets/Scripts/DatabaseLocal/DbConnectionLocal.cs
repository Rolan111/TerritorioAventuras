using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using UnityEngine;

public static class DbConnectionLocal
{
    private static bool isFristLoad = true;
    private static readonly string databaseSql = "Database/DatabaseSql.sql";
    private static readonly string database = "URI=file:Database/DataBase.db";

    public static T Write<T>(string query)
    {
        return PreloadQuery<T>(query,false);
    }

    public static T Read<T>(string query)
    {
        return PreloadQuery<T>(query, true);
    }

    private static T PreloadQuery<T>(string query, bool isRead)
    {
        if (isFristLoad)
        {
            Query<T>(ReadTextFile(), false);
            isFristLoad= false;
        }
        return Query<T>(query, isRead);
    }

    private static T Query<T>(string query, bool isQueryRead)
    {
        try
        {
            using (var connection = new SqliteConnection(database))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    if (isQueryRead)
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var rows = ConvertToString(reader);
                            var json = JsonConvert.SerializeObject(rows);
                            var result = JsonConvert.DeserializeObject<T>(json);
                            connection.Close();
                            return result;
                        }
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }catch (Exception ex) {
            Debug.Log(ex.ToString());

        }
        return default(T);
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

    private static string ReadTextFile()
    {
        StreamReader inp_stm = new StreamReader(databaseSql);
        StringBuilder stringBuilder = new StringBuilder();
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            stringBuilder.AppendLine(inp_ln);
        }
        inp_stm.Close();
        return stringBuilder.ToString();
    }
}
