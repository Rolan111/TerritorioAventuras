using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorColisionesMensajes : MonoBehaviour
{

    public GameObject activarDesactivarMensaje;
    private bool mensajeMostrado = false;
    public GameObject jugadorParaPausar;

    private void OnTriggerEnter(Collider other)
    {

        //Residuos
        if (!mensajeMostrado && other.CompareTag("Player"))
        {
            //Debug.Log("El jugador ha chocado con un RESIDUO Aluminio.");


            //activarDesactivarBarrera.IsDestroyed();
            //Destroy(other.gameObject);

            // Detiene el movimiento del personaje
            //jugadorParaPausar.GetComponent<Rigidbody>().velocity = Vector3.zero;
            // Impide que el personaje se desplace con fuerza
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            MostrarMensaje();
            mensajeMostrado = true;
        }

        void MostrarMensaje()
        {
            activarDesactivarMensaje.SetActive(true);
            //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
            //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false; //Pausar solo el movimeinto del jugador
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Se ha presionado Y desde el mensaje");
            activarDesactivarMensaje.SetActive(false);
            //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = true;
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            

            Destroy(gameObject);
        }
    }

    
}
