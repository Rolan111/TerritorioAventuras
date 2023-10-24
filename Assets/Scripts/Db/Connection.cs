using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using Unity.VisualScripting;
//using UnityEditor.MemoryProfiler;
using System;

public static class Connection
{

    private static MySqlConnection db;

    public static MySqlConnection connection()
    {
        string server = "localhost";
        string database = "territorioaventurasdb";
        string user = "root";
        string password = "";

        string stringConnection = "Server=" + server + "; Database=" + database + "; User=" + user + "; Password=" + password + "; Charset=utf8;";

        try
        {
            db = new MySqlConnection(stringConnection);
            db.Open();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            Debug.LogError(e);
        }

        return db;
    }

}
