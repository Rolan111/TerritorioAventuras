using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeActivacion : MonoBehaviour
{
    public GameObject objetoADesactivar;

    // M�todo para activar el GameObject
    public void ActivarObjeto()
    {
        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(true);
        }
    }

    // M�todo para desactivar el GameObject
    public void DesactivarObjeto()
    {
        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(false);
        }
    }
}
