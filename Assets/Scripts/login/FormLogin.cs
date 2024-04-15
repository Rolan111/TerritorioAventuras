using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;

public class LoginForm : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField password;
    public TMP_Text result;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    public void login()
    {

        validateData();

        var isLogin = UserApiLocal.FindByUserAndPassword(user.text, password.text);
        if (isLogin == null)
        {
            result.text = "";
            SceneManager.LoadScene("2 MenuPrincipal");
        }
        else
        {
            result.text = "Usuario o Contraseña Erronea";
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