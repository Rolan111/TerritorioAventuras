using TMPro;
using UnityEngine;

public class FormRegister : MonoBehaviour
{
    public TMP_Text result;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    public void Start()
    {
    }

    public void registrar()
    {
        UserDto userDto = new UserDto();
        userDto.school = "";

        UserApi.save(userDto); 
    }

    public void showFormLogin()
    {
        formLogin.SetActive(true);
        formRegister.SetActive(false);
    }
}
