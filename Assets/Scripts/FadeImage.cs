using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public float fadeDuration = 1f; // Duración de la animación de opacidad
    public float maxAlpha = 1f; // Opacidad máxima
    public float minAlpha = 0.3f; // Opacidad mínima

    private Image image; // Referencia al componente Image
    private bool fadingOut = false; // Estado de la animación

    void Start()
    {
        // Obtener la referencia al componente Image
        image = GetComponent<Image>();

        // Iniciar la animación
        StartFade();
    }

    void StartFade()
    {
        // Si la imagen está actualmente desapareciendo, detenerla
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

        // Llamar a StartFade nuevamente después de la duración de la animación
        Invoke("StartFade", fadeDuration);
    }
}
