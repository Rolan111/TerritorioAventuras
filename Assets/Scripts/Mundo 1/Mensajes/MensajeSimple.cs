using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeSimple : MonoBehaviour
{
    public GameObject activarDesactivarMensaje;

    private void OnTriggerEnter(Collider other)
    {

        //Residuos
        if (other.CompareTag("Player"))
        {
            MostrarMensaje();
            //mensajeMostrado = true;
        }

        void MostrarMensaje()
        {
            activarDesactivarMensaje.SetActive(true);
            //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
            //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false; //Pausar solo el movimeinto del jugador
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activarDesactivarMensaje.SetActive(false);
        }
    }

    private void Update()
    {
        if (activarDesactivarMensaje.activeSelf && Input.GetKey(KeyCode.Y))
        {
            activarDesactivarMensaje.SetActive(false);
        }
    }



}
