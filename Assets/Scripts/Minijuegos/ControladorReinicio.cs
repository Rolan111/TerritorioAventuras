using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorReinicio : MonoBehaviour
{

    //public Button miBoton; // Esta es la referencia al botón en el inspector

    //void Start()
    //{
    //    // Añadir un listener al botón
    //    miBoton.onClick.AddListener(OnClick);
    //}

    public void Reiniciar()
    {
        GameObject.Find("ControladorPrefabsMinijuegos").GetComponent<ControladorPrefabsMinijuegos>().RecargarPrefab();
    }

    public void juegoGanadoSalir()
    {
        GameObject.Find("DisparadorMinijuego1").GetComponent<DisparadorDeMinijuegos2D>().desactivarMinijuego2();
    }

    public void juegoGanadoSalir2()
    {
        GameObject.Find("DisparadorMinijuego2").GetComponent<DisparadorDeMinijuegos2D>().desactivarMinijuego2();
    }

}
