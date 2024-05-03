using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // Referencia al componente Image del bot�n
    public Sprite hoverImage; // Imagen que se cargar� cuando el mouse est� sobre el bot�n
    private Sprite originalImage; // Imagen original del bot�n

    void Start()
    {
        // Guarda la imagen original del bot�n
        originalImage = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambia la imagen del bot�n cuando el mouse entra en �l
        buttonImage.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaura la imagen original del bot�n cuando el mouse sale de �l
        buttonImage.sprite = originalImage;
    }
}
