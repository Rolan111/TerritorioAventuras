using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRegister : MonoBehaviour
{
    MySqlConnection db;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    public void Start()
    {
        db = Connection.connection();
    }

    public void showFormLogin()
    {
        formLogin.SetActive(true);
        formRegister.SetActive(false);
    }
}
