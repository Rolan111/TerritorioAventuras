using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlBote : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del bote
    public float velocidadRotacion = 100f; // Velocidad de rotación del bote

    private bool sonidoReproducido = false;

    private void Start()
    {
        GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        // Movimiento hacia adelante
        if (Input.GetKey(KeyCode.UpArrow))//se presiona
        {
            if (!sonidoReproducido)
            {
                // Reproducir el sonido solo si no se ha reproducido ya
                GetComponent<AudioSource>().Play();
                sonidoReproducido = true;
                
            }
            
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))//se suelta
        {
            //audioSource.PlayOneShot(sonidoAcelerar);
            //sonidoAcelerar.GetComponent<AudioSource>().Play();

            //transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            //GameObject.FindAnyObjectByType<AudioSource>().Stop();
            GetComponent<AudioSource>().Stop();
            sonidoReproducido = false;
        }

        // Movimiento hacia atrás
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * velocidad * Time.deltaTime);
        }

        // Rotación hacia la izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, -velocidadRotacion * Time.deltaTime);
        }

        // Rotación hacia la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
        }
    }
}
