using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    private static int contador = 0;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        if (!item)
        {
            item = DragHandler.objBeingDraged;
            if (gameObject.tag == item.tag)//Comprueba que las etiquetas sean iguales para dejar reposar
            {
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                contador = contador+1;
                Debug.Log("El contador esta en: " + contador);
            }
            if (contador == 3)
            {
                Debug.Log("El contenedor esta LLENO en 3");
                SceneManager.LoadScene("NivelCompleto");
            }
            
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
            contador -= 1;
            Debug.Log("El contador esta en: " + contador);
            
        }
    }
}
