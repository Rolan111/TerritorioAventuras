using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DetectorColisiones : MonoBehaviour
{
    //[SerializeField] public float cantidadPuntos;
    //[SerializeField] private LogicaPuntajes logicaPuntajes;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Se ha colisionado con el jugador");
            //Destroy(other.gameObject); // Destruye el objeto recogido
        }

        //logicaPuntajes.ContadorMonedas(cantidadPuntos);
        //Destroy(gameObject);
    }


}
