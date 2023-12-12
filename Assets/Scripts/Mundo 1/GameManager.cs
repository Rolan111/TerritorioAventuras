using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Objeto que quieres mostrar u ocultar
    public GameObject menuMostrarOcultar;
    public GameObject configuracionesMostrarOcultar;

    // Método para mostrar el objeto
    public void MostrarOcultarMenu()
    {
        configuracionesMostrarOcultar.SetActive(false);
        if (menuMostrarOcultar.activeSelf)
        {
            
            menuMostrarOcultar.SetActive(false);
        }
        else
        {
            menuMostrarOcultar.SetActive(true);
        }
    }

    public void MostrarOcultarConfiguraciones()
    {
        menuMostrarOcultar.SetActive(false);
        if (configuracionesMostrarOcultar.activeSelf)
        {
            configuracionesMostrarOcultar.SetActive(false);
        }
        else
        {
            configuracionesMostrarOcultar.SetActive(true);
        }
    }
}
