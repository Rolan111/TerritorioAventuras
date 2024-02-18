using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DisparadorDeVideo : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject personaje;
    public GameObject activarDesactivarTexto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activarDesactivarTexto.SetActive(true);
            //Liberar ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ReproducirVideo();
            Debug.Log("El objeto chocón con el jugador.");
            
            //Destroy(other.gameObject);
        }
    }

    

    private bool videoReproduciendo = false;

    void Start()
    {
        videoPlayer.loopPointReached += VideoTerminado;
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
        videoReproduciendo = true;
        personaje.GetComponent<SUPERCharacterAIO>().enabled = false; // Llama a un método en el script de movimiento del personaje para pausar su movimiento
        personaje.GetComponent<AudioSource>().enabled = false;
        videoPlayer.Play();
    }

    public void VideoTerminado(VideoPlayer vp)
    {
        activarDesactivarTexto.SetActive(false);
        videoReproduciendo = false;
        Destroy(gameObject);
        Destroy(videoPlayer);
        personaje.GetComponent<SUPERCharacterAIO>().enabled = true; // Llama a un método en el script de movimiento del personaje para reanudar su movimiento
        personaje.GetComponent<AudioSource>().enabled = true;
        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
