using UnityEngine;

public class FormRegister : MonoBehaviour
{

    public GameObject formLogin = null;

    public void Start()
    {
    }

    public void showFormLogin()
    {
        formLogin.SetActive(true);
        gameObject.SetActive(false);
    }
}
