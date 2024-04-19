using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorDeMinijuegos2D : MonoBehaviour
{
    public GameObject controladorActivarDesactivarMinijuego;
    public GameObject jugadorActivarDesactivar;
    public GameObject activarDesactivarNPC2;
    public GameObject activarDesactivarPortal;

    public int minijuegoAActivar;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            controladorActivarDesactivarMinijuego.SetActive(true);
            controladorActivarDesactivarMinijuego.GetComponent<ControladorPrefabsMinijuegos>().SpawnPrefab(minijuegoAActivar);
            jugadorActivarDesactivar.SetActive(false);
            //Liberar ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void desactivarMinijuego(GameObject minijuego,GameObject jugador)//No se ha usado
    {

        minijuego.SetActive(false);
        jugador.SetActive(true);

        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    public void desactivarMinijuego2()//EL 2 es por la segunda versión del método
    {

        //controladorActivarDesactivarMinijuego.SetActive(false);//se necesita este controlador para el otro minijuego

        //Destroy(activarDesactivarMinijuego);

        //Método para ELIMINAR todos los clones en base al nombre de un tag, tambi'en se puede en base al nombre de un script
        GameObject[] rainLeaves = GameObject.FindGameObjectsWithTag("TagParaEliminarClones");
        foreach (GameObject rainLeaf in rainLeaves)
        {
            Destroy(rainLeaf);
        }
        
        jugadorActivarDesactivar.SetActive(true);

        //Volver a bloquear el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (minijuegoAActivar==2){ activarDesactivarPortal.SetActive(true); }

        Destroy(gameObject);
    }

    public void ActivarPortalDeSalida()
    {
        activarDesactivarPortal.SetActive(true);
    }

    public void ActivarNPC2()
    {
        activarDesactivarNPC2.SetActive(true);
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
