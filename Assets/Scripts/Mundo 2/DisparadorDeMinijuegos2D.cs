using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorDeMinijuegos2D : MonoBehaviour
{
    public GameObject activarDesactivarMinijuego;
    public GameObject jugadorActivarDesactivar;
    public GameObject activarDesactivarPortal;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            activarDesactivarMinijuego.SetActive(true);
            jugadorActivarDesactivar.SetActive(false);
            //Liberar ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void desactivarMinijuego(GameObject minijuego,GameObject jugador)
    {

        minijuego.SetActive(false);
        jugador.SetActive(true);

        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    public void desactivarMinijuego2()
    {

        //activarDesactivarMinijuego.SetActive(false);
        Destroy(activarDesactivarMinijuego);
        jugadorActivarDesactivar.SetActive(true);

        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(gameObject);

    }

    public void activarPortalDeSalida()
    {
        activarDesactivarPortal.SetActive(true);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
