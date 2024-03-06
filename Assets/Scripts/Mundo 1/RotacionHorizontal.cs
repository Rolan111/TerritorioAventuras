using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionHorizontal : MonoBehaviour
{
    public float velocidadRotacion = 30f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto constantemente en el eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
