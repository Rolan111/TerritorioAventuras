using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaAlBote : MonoBehaviour
{

    public GameObject mensajePanel; // Panel que contiene el mensaje de pregunta
    public GameObject barcoTemporal; //Será desactivado después de aceptar
    public GameObject barco; // El objeto del barco que será activado después de aceptar
    public GameObject jugadorActivaDesactivar;
    //public GameObject objetosADesactivar;

    //Para mover el objeto
    public Transform objetoAMover;
    public Vector3 nuevaPosicion = new Vector3(84.6999969f, 8f, 32.3999996f);
    private bool isPersonajeMovido = false;


    private bool preguntaMostrada = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!preguntaMostrada && collision.gameObject.CompareTag("Player"))
        {
            preguntaMostrada = true;
            MostrarMensaje();
        }
        
    }

    void MostrarMensaje()
    {
        mensajePanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego mientras se muestra el mensaje
    }

    void Update()
    {
        if (preguntaMostrada && Input.GetKeyDown(KeyCode.Y))
        {
            Aceptar();
        }
    }

    void Aceptar()
    {
        //Desactivamos el jugador
        // Encuentra todos los objetos con la etiqueta deseada
        
        //GameObject[] objetosADesactivar = GameObject.FindGameObjectsWithTag("Player");
        
        //// Itera sobre cada objeto encontrado y los desactiva
        //foreach (GameObject objeto in objetosADesactivar)
        //{
        //    if (objeto.activeSelf)
        //    {
        //        objeto.SetActive(false);
        //    }
        //    else
        //    {
        //        objeto.SetActive(true);
        //        isPersonajeMovido = true;
        //    }

        //}

        //Jugador
        if (jugadorActivaDesactivar.activeSelf)
        {
            jugadorActivaDesactivar.SetActive(false);
        }
        else
        {
            isPersonajeMovido = true;
            jugadorActivaDesactivar.SetActive(true);
        }

        if (!isPersonajeMovido)
        {
            objetoAMover.position = nuevaPosicion;
        }
        
        mensajePanel.SetActive(false);

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
