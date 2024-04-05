using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaAlBote : MonoBehaviour
{

    public GameObject[] mensajesPanel; // Panel que contiene el mensaje de pregunta
    public GameObject barcoTemporal; //Será desactivado después de aceptar
    public GameObject barco; // El objeto del barco que será activado después de aceptar
    public GameObject jugadorActivaDesactivar;
    //public GameObject objetosADesactivar;

    //Para mover el objeto
    public Transform objetoAMover;
    public Vector3 nuevaPosicion = new Vector3(84.6999969f, 8f, 32.3999996f);
    private bool isPersonajeMovido = false;


    private bool preguntaMostrada = false;
    private bool preguntaMostradaFalta = false;
    public bool entrandoAlBote = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!preguntaMostrada && collision.gameObject.CompareTag("Player"))
        {
            if (entrandoAlBote)//Si apenas entra al bote por primera Vez
            {
                preguntaMostrada = true;
                MostrarMensaje();
            }
            else
            {
                // Encuentra el GameObject que tiene Script1 adjunto, el script que tiene el contador
                GameObject objetoConScript1 = GameObject.Find("Bote");

                if (objetoConScript1 != null)
                {
                    // Obtén la referencia al script Script1 desde el GameObject
                    DetectorColisionesBote script1 = objetoConScript1.GetComponent<DetectorColisionesBote>();

                    if (script1 != null)
                    {
                        // Ahora puedes acceder a la variable pública miVariablePublica
                        int valorDeLaVariablePublica = script1.contadorTotalDeResiduos;
                        Debug.Log("Valor de miVariablePublica en Script1: " + valorDeLaVariablePublica);
                        if (valorDeLaVariablePublica<7)
                        {
                            preguntaMostradaFalta = true;
                            MostrarMensajeValorRestante();
                        }
                        else
                        {
                            preguntaMostrada = true;
                            //mensajesPanel[1].GetComponent<DialogueManager>().StartDialogue();
                            MostrarMensaje();
                        }
                    }
                    else
                    {
                        Debug.LogError("Script1 no encontrado en el objeto " + objetoConScript1.name);
                    }
                }
                else
                {
                    Debug.LogError("Objeto con nombre NombreDelObjetoConScript1 no encontrado.");
                }
            }
            

        }
        
    }

    void MostrarMensajeValorRestante()
    {
        mensajesPanel[0].SetActive(true);
        //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
    }

    void MostrarMensaje()
    {
        mensajesPanel[1].SetActive(true);

        //if (entrandoAlBote) //Solo cuando se entra al bote por primera vez
        //{
        //    mensajesPanel[1].GetComponent<DialogueManager>().StartDialogue();
        //}

        mensajesPanel[1].GetComponent<DialogueManager>().StartDialogue();

        //Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
        //Pausar jugador
        jugadorActivaDesactivar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }


    void Update()
    {
        if (preguntaMostrada && Input.GetKeyDown(KeyCode.Tab))
        {
            if (entrandoAlBote)
            {
                mensajesPanel[1].GetComponent<DialogueManager>().StopDialogue();
            }
            mensajesPanel[1].GetComponent<DialogueManager>().StopDialogue();

            Aceptar();
        }
        if (preguntaMostradaFalta && Input.GetKeyDown(KeyCode.Y))
        {
            Aceptar2();
        }
    }

    void Aceptar2()
    {
        mensajesPanel[0].SetActive(false);
    }

    void Aceptar()
    {
        //Jugador
        if (jugadorActivaDesactivar.activeSelf)
        {
            jugadorActivaDesactivar.SetActive(false);
        }
        else
        {
            isPersonajeMovido = true;
            jugadorActivaDesactivar.SetActive(true);
            //Se retoma el movimiento del personaje
            jugadorActivaDesactivar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            jugadorActivaDesactivar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            mensajesPanel[2].SetActive(true);
        }

        if (!isPersonajeMovido)
        {
            objetoAMover.position = nuevaPosicion;
        }

        mensajesPanel[1].SetActive(false);

        //Barco Temporal
        if (barcoTemporal.activeSelf)
        {
            barcoTemporal.SetActive(false);
        }
        else
        {
            barcoTemporal.SetActive(true);
        }

        //Barco
        if (barco.activeSelf)
        {
            barco.SetActive(false);
        }
        else
        {
            barco.SetActive(true);
        }

        Time.timeScale = 1f; // Reanudar el juego después de aceptar
        Destroy(gameObject); // Destruir el objeto con el que colisionó el jugador

    }

}
