using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionesPlayer : MonoBehaviour
{
    //[SerializeField] public float cantidadPuntos;
    [SerializeField] private LogicaPuntajes[] logicaPuntajes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monedas"))
        {
            Debug.Log("El jugador ha chocado con una MONEDA.");
            logicaPuntajes[0].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/Organicos"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Organico.");
            logicaPuntajes[1].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/Envases"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Envases.");
            logicaPuntajes[2].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/PapelYCarton"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Papel y Cartón.");
            logicaPuntajes[3].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
    }
}
