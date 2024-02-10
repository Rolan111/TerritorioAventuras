using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaAlBote : MonoBehaviour
{

    public GameObject mensajePanel; // Panel que contiene el mensaje de pregunta
    public GameObject barco; // El objeto del barco que será activado después de aceptar

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
        GameObject[] objetosADesactivar = GameObject.FindGameObjectsWithTag("Player");

        // Itera sobre cada objeto encontrado y los desactiva
        foreach (GameObject objeto in objetosADesactivar)
        {
            objeto.SetActive(false);
        }

        mensajePanel.SetActive(false);
        barco.SetActive(true);
        Time.timeScale = 1f; // Reanudar el juego después de aceptar
        Destroy(gameObject); // Destruir el objeto con el que colisionó el jugador
    }

}
