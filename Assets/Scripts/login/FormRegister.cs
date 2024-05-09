using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FormRegister : MonoBehaviour
{
    private TMP_Text result;
    private TMP_InputField nombre, edad, email, insEducativa, usuario, contrasena, contrasenaConfirmar;
    private TMP_Dropdown sexo;

    public GameObject formLogin = null;
    public GameObject formRegister = null;

    private void Awake()
    {
        nombre = GameObject.Find("Nombre").GetComponent<TMP_InputField>();
        edad = GameObject.Find("Edad").GetComponent<TMP_InputField>();
        sexo = GameObject.Find("Sexo").GetComponent<TMP_Dropdown>();
        email = GameObject.Find("Email").GetComponent<TMP_InputField>();
        insEducativa = GameObject.Find("InsEducativa").GetComponent<TMP_InputField>();
        usuario = GameObject.Find("Usuario").GetComponent<TMP_InputField>();
        contrasena = GameObject.Find("Contrasena").GetComponent<TMP_InputField>();
        contrasenaConfirmar = GameObject.Find("ContrasenaConfirmar").GetComponent<TMP_InputField>();
        result = GameObject.Find("ResultadoRegistro").GetComponent<TMP_Text>();
    }

    private bool validateData()
    {
        if (nombre.text == "" || edad.text == "" || sexo.value < 0 || email.text == "" || insEducativa.text == "" || usuario.text == "" || contrasena.text == "" || contrasenaConfirmar.text == "")
        {
            result.text = "Llenar todos los campos requeridos.";
            return false;
        }
        else
        {
            if (contrasena.text != contrasenaConfirmar.text)
            {
                result.text = "Las contraseñas son diferentes.";
                return false;
            }
            else
            {
                result.text = "";
                return true;
            }
        }
    }

    public void registrar()
    {
        if (validateData())
        {
            UserModel userDto = new UserModel();
            userDto.name = nombre.text;
            userDto.age = edad.text;
            userDto.id_gender = sexo.value + 1;
            userDto.email = email.text;
            userDto.school = insEducativa.text;
            userDto.user = usuario.text;
            userDto.password = contrasena.text;
            userDto.id_rol = 1;

            if (UserApiLocal.Save(userDto) > 0)
            {
                result.text = "Registro guardado correctamente.";
                result.color = new Color32(69, 240, 60, 255);
                clearForm();
                StartCoroutine(CoroutineOcultarFormularioRegistro());
            }
            else
            {
                result.text = "Error al guardar el registro.";
                result.color = new Color32(204, 80, 80, 255);
            }
        }
    }

    IEnumerator CoroutineOcultarFormularioRegistro()
    {
        yield return new WaitForSeconds(2f);
        formRegister.SetActive(false);
        formLogin.SetActive(true);
    }

    private void clearForm()
    {
        nombre.text = "";
        edad.text = "";
        email.text = "";
        insEducativa.text = "";
        usuario.text = "";
        contrasena.text = "";
        contrasenaConfirmar.text = "";
    }

    public void showFormLogin()
    {
        formLogin.SetActive(true);
        formRegister.SetActive(false);
    }
}
