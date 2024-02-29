using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorColisionesMensajes : MonoBehaviour
{

    public GameObject activarDesactivarMensaje;
    private bool mensajeMostrado = false;
    public bool bloqueoTotalDePersonaje;
    public bool desbloqueoDeRaton;
    public GameObject jugadorParaPausar;

    private void OnTriggerEnter(Collider other)
    {

        //Residuos
        if (!mensajeMostrado && other.CompareTag("Player"))
        {
            

            // Impide que el personaje se desplace con fuerza
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (bloqueoTotalDePersonaje)
            {
                jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false; //Pausar la cámara también
            }

            if(desbloqueoDeRaton) Cursor.lockState = CursorLockMode.None; Cursor.visible = true;

            MostrarMensaje();
            mensajeMostrado = true;
        }

        void MostrarMensaje()
        {
            activarDesactivarMensaje.SetActive(true);
            //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
        }


    }

    private void Update()
    {
        if (mensajeMostrado && Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Se ha presionado Y desde el mensaje");
            activarDesactivarMensaje.SetActive(false);
            //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = true;
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            if (bloqueoTotalDePersonaje)
            {
                jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = true;
            }
            if (desbloqueoDeRaton) Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;

            Destroy(gameObject);
        }
    }

    
}
