using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorDialogueSimple : MonoBehaviour
{
    //public GameObject barreraPrincipal;
    public GameObject ObjetoConDialogue;

    private void OnTriggerEnter(Collider other)
    {
        ObjetoConDialogue.GetComponent<DialogueManager>().StartDialogue();
        StartCoroutine(EjecutarDespuesDeTiempo(7f));
    }

    IEnumerator EjecutarDespuesDeTiempo(float tiempo)
    {
        //barreraPrincipal.SetActive(false);
        yield return new WaitForSeconds(tiempo); // Espera 'tiempo' segundos
        
        ObjetoConDialogue.GetComponent<DialogueManager>().StopDialogue();
        //barreraPrincipal.SetActive(true);
    }
}
