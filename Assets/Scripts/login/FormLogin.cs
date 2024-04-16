using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;

public class LoginForm : MonoBehaviour
{
    private TMP_InputField user, password;
    private TMP_Text result;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    private void Awake()
    {
        user = GameObject.Find("User").GetComponent<TMP_InputField>();
        password = GameObject.Find("Password").GetComponent<TMP_InputField>();
        result = GameObject.Find("Resultado").GetComponent<TMP_Text>();
    }

    public void login()
    {
        if(validateData()){
            var userLogin = UserApiLocal.FindByUserAndPassword(user.text, password.text);
            if (userLogin != null)
            {
                // vaciar campo, guardar usuario de sesion y cambiar de escena
                result.text = "";
                UserApiLocal.UserLogin = userLogin;
                SceneManager.LoadScene("2 MenuPrincipal");
            }
            else
            {
                result.text = "Usuario o Contraseña Erronea";
            }
        }
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