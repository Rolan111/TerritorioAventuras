using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    private static int contador = 0;
    //private bool detectorCoincidencia=false;

    public Image imagen;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        if (!item)
        {
            item = DragHandler.objBeingDraged;
            if (gameObject.tag == item.tag)//Comprueba que las etiquetas sean iguales para dejar reposar
            {
                //detectorCoincidencia = true;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;

                Destroy(item);

                //para colocar la imagen en cada lugar, se pregunta por nombre de la etiqueta y se hace coincidir.

                //Cambiar color de imagen

                if (imagen != null)
                {
                    // Cambia el color de la imagen a rojo (puedes usar cualquier otro color)
                    if (item.tag == "Rojo")
                    {
                        //aqui va la imagen
                        imagen.color = Color.red;
                    }
                    if (item.tag == "Amarillo")
                    {
                        //aqui va la imagen
                        imagen.color = Color.yellow;
                    }
                    if (item.tag == "Azul")
                    {
                        //aqui va la imagen
                        imagen.color = Color.blue;
                    }
                    
                }
                else
                {
                    Debug.LogWarning("La imagen no está asignada en el Inspector.");
                }
                contador = contador + 1;
                Debug.Log("El contador esta en: " + contador);

            }
            //else
            //{
            //    //contador -= 1;
            //}


            if (contador == 3)
            {
                Debug.Log("El contenedor esta LLENO en 3");
                contador = 0;
                SceneManager.LoadScene("NivelCompleto");
            }
            
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            //if (detectorCoincidencia==false)
            //{
            //    contador -= 1;
            //}
            Debug.Log("Remover");
            item = null;
            //Debug.Log("Fuera: El contador esta en: " + contador);
            
        }
    }
}
