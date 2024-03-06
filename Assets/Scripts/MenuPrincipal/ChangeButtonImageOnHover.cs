using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeButtonImageOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite;  // Imagen normal del botón
    public Sprite hoverSprite;   // Imagen cuando el mouse está sobre el botón

    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError("No se encontró el componente Image en el botón.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null && hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null && normalSprite != null)
        {
            buttonImage.sprite = normalSprite;
        }
    }
}
