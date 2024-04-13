using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorReinicio : MonoBehaviour
{

    //public Button miBoton; // Esta es la referencia al bot�n en el inspector

    //void Start()
    //{
    //    // A�adir un listener al bot�n
    //    miBoton.onClick.AddListener(OnClick);
    //}

    public void Reiniciar()
    {
        GameObject.Find("ControladorPrefabsMinijuegos").GetComponent<ControladorPrefabsMinijuegos>().RecargarPrefab();
    }

    public void juegoGanadoSalir()
    {
        GameObject.Find("DisparadorMinijuego2").GetComponent<DisparadorDeMinijuegos2D>().desactivarMinijuego2();
    }
}
