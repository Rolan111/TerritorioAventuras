using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Se ha usado para im�genes y botones
public class ResizeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 originalSize; // Tama�o original del bot�n
    public Vector2 enlargedSize; // Tama�o agrandado del bot�n
    public float transitionSpeed = 5f; // Velocidad de transici�n entre tama�os

    private RectTransform buttonRectTransform; // Referencia al RectTransform del bot�n
    private bool isMouseOver = false; // Estado de si el mouse est� sobre el bot�n

    void Start()
    {
        // Obtener la referencia al RectTransform del bot�n
        buttonRectTransform = GetComponent<RectTransform>();

        // Guardar el tama�o original del bot�n
        originalSize = buttonRectTransform.sizeDelta;
    }

    void Update()
    {
        // Transici�n del tama�o del bot�n
        Vector2 targetSize = isMouseOver ? enlargedSize : originalSize;
        buttonRectTransform.sizeDelta = Vector2.Lerp(buttonRectTransform.sizeDelta, targetSize, Time.deltaTime * transitionSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Establecer el estado de que el mouse est� sobre el bot�n
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Establecer el estado de que el mouse ya no est� sobre el bot�n
        isMouseOver = false;
    }
}
