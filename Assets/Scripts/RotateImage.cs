using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación

    // Update is called once per frame
    void Update()
    {
        // Rotar la imagen en el eje Z
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
