using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoginForm : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField password;
    public TMP_Text result;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    public void login()
    {
        List<AvatarModel> response = AvatarApiLocal.findAll();
        Debug.Log(response);

        if (!validateData())
        {
            return;
        }

        UserDto userDto = new UserDto();
        userDto.user = user.text;
        userDto.password = password.text;

        var isLogin = UserApiCloud.login(userDto);
        if (!isLogin)
        {
            result.text = "Usuario o Contraseña Erronea";
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