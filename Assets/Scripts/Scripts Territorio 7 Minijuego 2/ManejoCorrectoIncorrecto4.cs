using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoCorrectoIncorrecto4 : MonoBehaviour
{
    public GameObject correcto;
    public GameObject incorrecto;

    public void Correcto()//La lógica para ganar está en el word manager, por eso no se aumenta ningún contador.
    {
        correcto.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    public void Incorrecto()
    {
        GameObject contadorDeVidas = GameObject.Find("txtContadorDeVidas");
        incorrecto.SetActive(true);
        StartCoroutine(HideAfterDelay());
        contadorDeVidas.GetComponent<ContadorDeVidas4>().menosVida();
    }

    IEnumerator HideAfterDelay()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(2f);
        correcto.SetActive(false);
        incorrecto.SetActive(false);
    }

}
