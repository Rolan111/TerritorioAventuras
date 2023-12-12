using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVertical : MonoBehaviour
{
    public float velocidad = 2.0f;  // Velocidad de movimiento
    public float amplitud = 1.0f;   // Amplitud del movimiento
    private Vector3 posicionInicial; // Posición inicial del objeto

    void Start()
    {
        // Guardar la posición inicial del objeto
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcular el desplazamiento vertical usando la función sinusoidal
        float desplazamientoVertical = Mathf.Sin(Time.time * velocidad) * amplitud;

        // Actualizar la posición del objeto
        transform.position = posicionInicial + new Vector3(0, desplazamientoVertical, 0);
    }
}
