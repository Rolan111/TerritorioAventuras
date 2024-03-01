using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivacionYDestruccionRetardada : MonoBehaviour
{
    public GameObject activarDesactivarMensaje;

    private void Start()
    {
        
    }

    public void Desactivar()
    {
        StartCoroutine(EjecutarDespuesDeTiempo(4f));
    }

    IEnumerator EjecutarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera 'tiempo' segundos

        // Lógica a ejecutar después del tiempo especificado
        activarDesactivarMensaje.SetActive(false);
        Debug.Log("Se ha ejecutado después de " + tiempo + " segundos.");
    }


}
