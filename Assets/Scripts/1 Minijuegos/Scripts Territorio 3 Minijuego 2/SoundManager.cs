using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public AudioClip[] audiosInstrumentos;

    // Start is called before the first frame update
    void Start()
    {
        ReproducirSonidoInstrumento("ID1");
    }

    public void ReproducirSonidoInstrumento(string valorBoton)
    {
        int index = 0;
        switch (valorBoton)
        {
            case "ID1":
                index = 0;
                break;
            case "ID2":
                index = 1;
                break;
            case "ID3":
                index = 2;
                break;
            case "ID4":
                index = 3;
                break;
            case "ID5":
                index = 4;
                break;
            case "ID6":
                index = 5;
                break;
            case "ID7":
                index = 6;
                break;
            case "ID8":
                index = 7;
                break;
            default:
                Debug.Log("Opcion de sonido NO VALIDA");
                break;
        }
        // Asegúrate de que el índice está dentro del rango del array de AudioClips
        if (index >= 0 && index < audiosInstrumentos.Length)
        {
            // Asigna el AudioClip seleccionado al AudioSource
            m_AudioSource.clip = audiosInstrumentos[index];

            // Reproduce el sonido
            m_AudioSource.Play();
        }
        else
        {
            Debug.LogError("Índice fuera de rango.");
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
