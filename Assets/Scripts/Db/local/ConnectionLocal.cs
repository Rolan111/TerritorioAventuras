using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class ConnectionLocal{

    private MySqlConnection db;

    public MySqlConnection connection()
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
