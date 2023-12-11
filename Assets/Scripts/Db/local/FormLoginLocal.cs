using UnityEngine;
using MySql.Data.MySqlClient;

public class LoginFormLocal : MonoBehaviour
{
	MySqlConnection db;
    ConnectionLocal connectionLocal;
    
	public void Start()
    {
    }

	public bool login(string user, string pass) {
        db = connectionLocal.connection();
        string sql = "select * from usuarios where usuario = '" + user + "' and contrasena = '" + pass + "'";

        MySqlCommand command = new MySqlCommand(sql, db);
        MySqlDataReader reader = command.ExecuteReader();

        bool isLogin = reader.HasRows;
        reader.Close();

        return isLogin;
    }
}