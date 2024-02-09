using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorColisionesBote : MonoBehaviour
{
    //[SerializeField] public float cantidadPuntos;
    [SerializeField] private LogicaPuntajes[] logicaPuntajes;

    public GameObject[] activarResiduo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monedas"))
        {
            Debug.Log("El jugador ha chocado con una MONEDA.");
            logicaPuntajes[0].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }

        //Residuos
        else if (other.CompareTag("Residuos/Aluminio"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Aluminio.");
            logicaPuntajes[1].ContadorPuntajes(1);
            Destroy(other.gameObject);
            activarResiduo[0].SetActive(true);
        }
        else if (other.CompareTag("Residuos/Envases"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Envases.");
            logicaPuntajes[2].ContadorPuntajes(1);

            if (other.name == "BotellaCerveza_01 ")
            {
                Debug.Log("El bote ha colisionado con la cerveza");
                activarResiduo[1].SetActive(true);
            }
            else
            {
                activarResiduo[2].SetActive(true);
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/PapelYCarton"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Papel y Cartón.");
            logicaPuntajes[3].ContadorPuntajes(1);
       

            if (other.name == "PapelArrugado_01 ")
            {
                activarResiduo[3].SetActive(true);
            }
            
            if (other.name == "PapelArrugado_02")
            {
                activarResiduo[4].SetActive(true);
            }
            
            if(other.name == "VasoDesechable_01")
            {
                activarResiduo[5].SetActive(true);
            }

            if (other.name == "VasoDesechable_02")
            {
                activarResiduo[6].SetActive(true);
            }

            Destroy(other.gameObject);

        }

        //*****


    }

}
