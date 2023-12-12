using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DetectorColisiones : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoMonedas;
    // Puede NO SER NECESARIO para la mayoria de los casos ya que el detector de colisiones lo tiene el JUGADOR

    //[SerializeField] public float cantidadPuntos;
    //[SerializeField] private LogicaPuntajes logicaPuntajes;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Se ha colisionado con el jugador");
            //Destroy(other.gameObject); // Destruye el objeto recogido
            MenuPrinCambioEscena.instance.EjecutarSonido(sonidoMonedas);

        }

        //logicaPuntajes.ContadorMonedas(cantidadPuntos);
        //Destroy(gameObject);
    }


}
