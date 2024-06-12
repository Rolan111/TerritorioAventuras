using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Se ha usado para imágenes y botones
public class ResizeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 originalSize; // Tamaño original del botón
    public Vector2 enlargedSize; // Tamaño agrandado del botón
    public float transitionSpeed = 5f; // Velocidad de transición entre tamaños

    private RectTransform buttonRectTransform; // Referencia al RectTransform del botón
    private bool isMouseOver = false; // Estado de si el mouse está sobre el botón

    void Start()
    {
        // Obtener la referencia al RectTransform del botón
        buttonRectTransform = GetComponent<RectTransform>();

        // Guardar el tamaño original del botón
        originalSize = buttonRectTransform.sizeDelta;
    }

    void Update()
    {
        // Transición del tamaño del botón
        Vector2 targetSize = isMouseOver ? enlargedSize : originalSize;
        buttonRectTransform.sizeDelta = Vector2.Lerp(buttonRectTransform.sizeDelta, targetSize, Time.deltaTime * transitionSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Establecer el estado de que el mouse está sobre el botón
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Establecer el estado de que el mouse ya no está sobre el botón
        isMouseOver = false;
    }
}
