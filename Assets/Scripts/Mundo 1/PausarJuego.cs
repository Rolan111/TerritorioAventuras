using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // Puedes cambiar la tecla seg�n tus preferencias
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuegoMetodo();
        }
    }

    void PausarJuegoMetodo()
    {
        Time.timeScale = 0f;  // Detiene el tiempo
        juegoPausado = true;

        // Aqu� puedes mostrar un men� de pausa si lo deseas
        Debug.Log("Juego pausado");
    }

    void ReanudarJuego()
    {
        Time.timeScale = 1f;  // Reanuda el tiempo normal
        juegoPausado = false;

        // Aqu� puedes ocultar el men� de pausa si lo has mostrado
        Debug.Log("Juego reanudado");
    }
}
