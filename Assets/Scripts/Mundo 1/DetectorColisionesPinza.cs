using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorColisionesPinza : MonoBehaviour
{
    public GameObject activarDesactivarMensaje;
    public GameObject barreraADesactivar;
    private bool mensajeMostrado = false;
    public LogicaPuntajes logicaPuntajes;

    private void OnTriggerEnter(Collider other)
    {

        //Residuos
        if (!mensajeMostrado && other.CompareTag("Player"))
        {
            Destroy(barreraADesactivar);
            MostrarMensaje();
            mensajeMostrado = true;
            logicaPuntajes.ContadorPuntajes(10);
        }

        void MostrarMensaje()
        {
            activarDesactivarMensaje.SetActive(true);
            activarDesactivarMensaje.GetComponent<DesactivacionYDestruccionRetardada>().Desactivar();
            
            //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
            //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false; //Pausar solo el movimeinto del jugador
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            activarDesactivarMensaje.SetActive(false);

            //Destroy(gameObject);
        }
    }
}
