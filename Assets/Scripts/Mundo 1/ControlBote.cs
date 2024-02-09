using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBote : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del bote
    public float velocidadRotacion = 100f; // Velocidad de rotación del bote

    void Update()
    {
        // Movimiento hacia adelante
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
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
