using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTableroControl : MonoBehaviour
{
    public GameObject[] objetosHerramientas;
    public GameObject[] objetosInsignias;
    public GameObject[] objetosNiveles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarInsigniaYNivel(int currentScene)//Se muestran en base al cambio de escenas
    {
        Debug.Log("Se ha entrado a la logica para mostrar insignias");
        switch (currentScene)
        {
            case 3:
                objetosInsignias[0].SetActive(false);
                objetosNiveles[0].SetActive(false);
                break;
            case 4:
                objetosInsignias[1].SetActive(false);
                objetosNiveles[1].SetActive(false);
                break;
            case 5:
                objetosInsignias[2].SetActive(false);
                objetosNiveles[2].SetActive(false);
                break;
            case 6:
                objetosInsignias[3].SetActive(false);
                objetosNiveles[3].SetActive(false);
                break;
            case 7:
                objetosInsignias[4].SetActive(false);
                objetosNiveles[4].SetActive(false);
                break;
            case 8:
                objetosInsignias[5].SetActive(false);
                objetosNiveles[5].SetActive(false);
                break;
            case 9:
                objetosInsignias[6].SetActive(false);
                objetosNiveles[6].SetActive(false);
                break;
            default:
                Console.WriteLine("The number is neither 1 nor 2");
                break;
        }
    }

    public void MostarObjetoPorIndexArray(int index)//Se muestra objeto individual por index del array
    {
        objetosHerramientas[index].SetActive(false);
    }
}
