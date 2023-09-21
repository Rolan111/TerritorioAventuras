using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;

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
            }
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
        }
    }
}
