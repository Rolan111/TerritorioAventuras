using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public GameObject objetoDelPanel;
    public GameObject[] imagenes;
    private int capturaIndex;
    private bool coroutineRunning = false;

    public void AmpliarImagen(string valorBoton)
    {
        
        objetoDelPanel.SetActive(true);
        GameObject.Find("PanelGaleria").GetComponent<SmoothAppear>().DisparadorDeCoroutine();
        switch (valorBoton)
        {
            case "ID1":
                imagenes[0].SetActive(true);
                capturaIndex = 0;
                break;
            case "ID2":
                imagenes[1].SetActive(true);
                capturaIndex = 1;
                break;
            case "ID3":
                imagenes[2].SetActive(true);
                capturaIndex = 2;   
                break;
            case "ID4":
                imagenes[3].SetActive(true);
                capturaIndex = 3;
                break;
            case "ID5":
                imagenes[4].SetActive(true);
                capturaIndex = 4;
                break;
            
            default:
                Debug.Log("Opcion de Imagen NO VALIDA");
                break;
        }

        // Si la corrutina no está en ejecución, inicia la corrutina
        if (!coroutineRunning)
        {
            StartCoroutine(MyCoroutine());
            coroutineRunning = true;
        }
    }

    IEnumerator MyCoroutine()
    {
       
        yield return new WaitForSeconds(5f);

        // Cuando la corrutina termina, podemos hacer alguna acción adicional si es necesario
        imagenes[capturaIndex].SetActive(false);
        objetoDelPanel.SetActive(false);
        Debug.Log("La corrutina ha terminado.");

        // Reinicia la bandera de la corrutina
        coroutineRunning = false;
    }

    public void DetenerCoroutine()
    {
        // Si la corrutina está en ejecución, detén la corrutina
        if (coroutineRunning)
        {
            imagenes[capturaIndex].SetActive(false);
            StopCoroutine(MyCoroutine());
            coroutineRunning = false;
        }
    }
}
