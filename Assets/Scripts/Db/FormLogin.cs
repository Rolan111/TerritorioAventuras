using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using TMPro;
using System.Net;
using System;
using System.IO;

public class LoginForm : MonoBehaviour
{
    public bool conectedWithAPI = true;

    MySqlConnection db;

    public TMP_InputField user;
    public TMP_InputField password;
    public TMP_Text result;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    public void Start()
    {
        db = Connection.connection();
    }

    public void login()
    {
        if (!validateData())
        {
            return;
        }

        bool isLogin = false;
        if(conectedWithAPI){
            isLogin = loginAPI();
        }
        else
        {
            isLogin = loginLocal();
        }
        

        if (!isLogin)
        {
            result.text = "Usuario o Contraseña Erronea";
        }
        else
        {
            result.text = "";
        }
    }

    public bool loginLocal() {
        string sql = "select * from usuarios where usuario = '" + user.text + "' and contrasena = '" + password.text + "'";

        MySqlCommand command = new MySqlCommand(sql, db);
        MySqlDataReader reader = command.ExecuteReader();

        bool isLogin = reader.HasRows;
        reader.Close();

        return isLogin;
    }

    public bool loginAPI() {
        string formaturl = String.Format("http://localhost:8080/usuarios/findByUsuarioAndContrasena?usuario={0}&contrasena={1}", user.text, password.text);
        Debug.Log(formaturl);
        var request = (HttpWebRequest) WebRequest.CreateHttp(formaturl);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        Debug.Log(jsonResponse);
        return jsonResponse != "";
    }

    private bool validateData()
    {
        bool isValid = true;

        string userData = user.text;
        string passwordData = password.text;

        if (userData == "" && passwordData == "")
        {
            result.text = "Ingrese el Usuario y Contraseña";
            isValid = false;
        }
        else
        {
            if (userData == "")
            {
                result.text = "Ingrese el Usuario";
                isValid = false;
            }
            if (passwordData == "")
            {
                result.text = "Ingrese la Contraseña";
                isValid = false;
            }
        }
     
        return isValid;
    }

    public void showFormRegister()
    {
        formLogin.SetActive(false);
        formRegister.SetActive(true);
    }
}