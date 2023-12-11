using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
    
public class LoginForm : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField password;
    public TMP_Text result;

    public GameObject formRegister = null;

    public void login()
    {
        if (!validateData())
        {
            return;
        }

        var isLogin = ConnectionAPI.User.login(user.text, password.text);
        if (isLogin)
        {
            result.text = "Usuario o Contrase�a Erronea";
        }
        else
        {
            result.text = "";
            SceneManager.LoadScene("2 MenuPrincipal");
        }
    }

    private bool validateData()
    {
        bool isValid = true;

        string userData = user.text;
        string passwordData = password.text;

        if (userData == "" && passwordData == "")
        {
            result.text = "Ingrese el Usuario y Contrase�a";
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
                result.text = "Ingrese la Contrase�a";
                isValid = false;
            }
        }
     
        return isValid;
    }

    public void showFormRegister()
    {
        gameObject.SetActive(false);
        formRegister.SetActive(true);
    }
}