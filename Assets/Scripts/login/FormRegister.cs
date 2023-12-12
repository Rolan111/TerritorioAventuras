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
        Debug.Log("asdasdasdasdsa");
    }

    public void showFormLogin()
    {

        Debug.Log("asd");
        formLogin.SetActive(true);
        formRegister.SetActive(false);
    }
}
