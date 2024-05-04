using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothAppear : MonoBehaviour
{
    public Vector3 targetScale = Vector3.one; // Escala final del objeto (tamaño normal)
    public float appearSpeed = 20f; // Velocidad de aparición

    private Vector3 initialScale; // Escala inicial del objeto

    void Start()
    {
        // Guardar la escala inicial del objeto
        initialScale = transform.localScale;

        // Iniciar la corrutina para hacer aparecer el objeto suavemente
        StartCoroutine(AppearSmoothly());
    }

    public void DisparadorDeCoroutine()//Para acceder a este efecto desde OTRO SCRIPT
    {
        StartCoroutine(AppearSmoothly());
    }

    public IEnumerator AppearSmoothly()
    {
        // Iniciar con una escala pequeña (opcional)
        transform.localScale = Vector3.zero;

        // Interpolación suave entre la escala actual y la escala final
        float elapsedTime = 0f;
        while (elapsedTime < 15f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, elapsedTime * appearSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Establecer la escala final para asegurarse de que esté exactamente en el tamaño objetivo
        transform.localScale = targetScale;
    }

}
