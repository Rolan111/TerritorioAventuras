using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DisparadorDeVideo : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject personajeAPausar;
    public bool conTexto = true;
    public GameObject activarDesactivarTexto;

    //private bool videoReproduciendo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (conTexto)
            {
                activarDesactivarTexto.SetActive(true);
            }
            
            //Liberar ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ReproducirVideo();
            Debug.Log("El objeto chocón con el jugador.");
            
            //Destroy(other.gameObject);
        }
    }

    void Start()
    {
        videoPlayer.loopPointReached += VideoTerminado; //se suscribe a un evento que detecta cuando el video termina
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && !videoReproduciendo)
    //    {
    //        ReproducirVideo();
    //    }
    //}

    void ReproducirVideo()
    {
        //videoReproduciendo = true;
        personajeAPausar.GetComponent<SUPERCharacterAIO>().enabled = false; // Llama a un método en el script de movimiento del personaje para pausar su movimiento
        personajeAPausar.GetComponent<AudioSource>().enabled = false;
        //personajeAPausar.SetActive(false);

        videoPlayer.Play();
    }

    public void VideoTerminado(VideoPlayer vp)
    {
        if (conTexto)
        {
            activarDesactivarTexto.SetActive(false);
        }
        
        //videoReproduciendo = false;
        Destroy(gameObject);
        Destroy(videoPlayer);
        personajeAPausar.GetComponent<SUPERCharacterAIO>().enabled = true; // Llama a un método en el script de movimiento del personaje para reanudar su movimiento
        personajeAPausar.GetComponent<AudioSource>().enabled = true;
        //personajeAPausar.SetActive(true);

        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
