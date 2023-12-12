using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVertical : MonoBehaviour
{
    public float velocidad = 2.0f;  // Velocidad de movimiento
    public float amplitud = 1.0f;   // Amplitud del movimiento
    private Vector3 posicionInicial; // Posici�n inicial del objeto

    void Start()
    {
        // Guardar la posici�n inicial del objeto
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcular el desplazamiento vertical usando la funci�n sinusoidal
        float desplazamientoVertical = Mathf.Sin(Time.time * velocidad) * amplitud;

        // Actualizar la posici�n del objeto
        transform.position = posicionInicial + new Vector3(0, desplazamientoVertical, 0);
    }
}
