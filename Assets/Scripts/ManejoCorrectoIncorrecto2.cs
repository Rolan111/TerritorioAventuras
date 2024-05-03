using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoCorrectoIncorrecto2 : MonoBehaviour
{
    public GameObject correcto;
    public GameObject incorrecto;

    public void Correcto()
    {
        correcto.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    public void Incorrecto()
    {
        incorrecto.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(2f);
        correcto.SetActive(false);
        incorrecto.SetActive(false);
    }

}
