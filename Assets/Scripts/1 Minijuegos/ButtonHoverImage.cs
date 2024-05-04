using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // Referencia al componente Image del botón
    public Sprite hoverImage; // Imagen que se cargará cuando el mouse esté sobre el botón
    private Sprite originalImage; // Imagen original del botón

    void Start()
    {
        // Guarda la imagen original del botón
        originalImage = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambia la imagen del botón cuando el mouse entra en él
        buttonImage.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaura la imagen original del botón cuando el mouse sale de él
        buttonImage.sprite = originalImage;
    }
}
