using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public float fadeDuration = 1f; // Duraci�n de la animaci�n de opacidad
    public float maxAlpha = 1f; // Opacidad m�xima
    public float minAlpha = 0.3f; // Opacidad m�nima

    private Image image; // Referencia al componente Image
    private bool fadingOut = false; // Estado de la animaci�n

    void Start()
    {
        // Obtener la referencia al componente Image
        image = GetComponent<Image>();

        // Iniciar la animaci�n
        StartFade();
    }

    void StartFade()
    {
        // Si la imagen est� actualmente desapareciendo, detenerla
        if (fadingOut)
        {
            image.CrossFadeAlpha(maxAlpha, fadeDuration, true);
            fadingOut = false;
        }
        else
        {
            image.CrossFadeAlpha(minAlpha, fadeDuration, true);
            fadingOut = true;
        }

        // Llamar a StartFade nuevamente despu�s de la duraci�n de la animaci�n
        Invoke("StartFade", fadeDuration);
    }
}
