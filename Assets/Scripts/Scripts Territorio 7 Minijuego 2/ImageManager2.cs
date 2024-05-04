using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImageManager2 : MonoBehaviour
{
    public GameObject objetoDelPanel;
    public GameObject[] imagenes;

    private string sacarValorBoton;
    //private bool coroutineRunning = false;

    public void AmpliarImagen(string valorBoton)
    {
        sacarValorBoton = valorBoton;
        objetoDelPanel.SetActive(true);
        GameObject.Find("PanelGaleria").GetComponent<SmoothAppear>().DisparadorDeCoroutine(); //Para que aparezca lentamente
        switch (valorBoton)
        {
            case "ID1":
                imagenes[0].SetActive(true);
                break;
            case "ID2":
                imagenes[1].SetActive(true);
                break;
            case "ID3":
                imagenes[2].SetActive(true); 
                break;
            case "ID4":
                imagenes[3].SetActive(true);
                break;
            case "ID5":
                imagenes[4].SetActive(true);
                break;
            
            default:
                Debug.Log("Opcion de Imagen NO VALIDA");
                break;
        }

        // Si la corrutina no está en ejecución, inicia la corrutina
        //if (!coroutineRunning)
        //{
        //    StartCoroutine(MyCoroutine());
        //    coroutineRunning = true;
        //}
    }

    public void DesactivarImagenes()
    {
        // Recorre cada objeto en el array y desactívalo
        foreach (GameObject imagen in imagenes)
        {
            imagen.SetActive(false);
        }

        GameObject.Find("Diccionario").GetComponent<WordManager4>().eliminarClaveValor(sacarValorBoton);
        Debug.Log("El ID sacado es: "+sacarValorBoton);
    }

}
