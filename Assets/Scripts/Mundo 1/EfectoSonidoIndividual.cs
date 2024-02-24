using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonidoIndividual : MonoBehaviour
{

    [SerializeField] private AudioClip sonidoPinzaPowerUp;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            MenuPrinCambioEscena.instance.EjecutarSonido(sonidoPinzaPowerUp);

        }
    }
}
