using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfectoSonido : MonoBehaviour
{


    [SerializeField] private AudioClip sonido1;

    private void Start()
    {
        // Si est�s utilizando un bot�n interactivo, puedes agregar un listener as�:
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ReproduciendoSonido);
            Debug.Log("Se ha presionado de manera interactiva");
        }
    }

    private void ReproduciendoSonido()
    {
        MenuPrinCambioEscena.instance.EjecutarSonido(sonido1);
    }
}
