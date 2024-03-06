using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imageToLoad; // Asigna la imagen que quieres cargar desde el Inspector

    private Image displayImage;
    private bool mouseOver = false;

    void Start()
    {
        displayImage = Instantiate(imageToLoad, transform); // Creamos una copia de la imagen para mostrar al lado del botón
        displayImage.gameObject.SetActive(false); // La desactivamos inicialmente
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        displayImage.gameObject.SetActive(true); // Al pasar el mouse sobre el botón, activamos la imagen
        UpdateImagePosition();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        displayImage.gameObject.SetActive(false); // Al salir el mouse, desactivamos la imagen
    }

    void Update()
    {
        if (mouseOver)
        {
            UpdateImagePosition();
        }
    }

    void UpdateImagePosition()
    {
        RectTransform rt = displayImage.GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(corners);

        Vector3 buttonPos = corners[2]; // TopRight corner
        //Vector3 imagePos = new Vector3(buttonPos.x + rt.rect.width, buttonPos.y - 13, buttonPos.z); //Línea original
        Vector3 imagePos = new Vector3(buttonPos.x, buttonPos.y-13, buttonPos.z);
        displayImage.transform.position = imagePos;
    }
}
