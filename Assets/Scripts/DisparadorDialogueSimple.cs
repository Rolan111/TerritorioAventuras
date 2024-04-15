using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorDialogueSimple : MonoBehaviour
{
    //Además tiene un contador de TIEMPO
    public GameObject ObjetoConDialogue;
    public float tiempoParaDesaparecer;
    int cantidadDePreguntas = 0;
    int auxiliarDeConteo = 1;

    private void OnTriggerEnter(Collider other)
    {
        //ObjetoConDialogue.GetComponent<DialogueManager>().StartDialogue();
        //StartCoroutine(EjecutarDespuesDeTiempo(tiempoParaDesaparecer));
        métodoDispararDiálogo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Se ha colisionado sin trigger con el muro");
    }

    public void métodoDispararDiálogo()
    {
        cantidadDePreguntas = ObjetoConDialogue.GetComponent<DialogueManager>().GetNumberOfQuestions();
        //Debug.Log("La cantidad de preguntas es: " + cantidadDePreguntas);
        ObjetoConDialogue.GetComponent<DialogueManager>().StartDialogue();
        
        StartCoroutine(EjecutarDespuesDeTiempo(tiempoParaDesaparecer));
    }

    IEnumerator EjecutarDespuesDeTiempo(float tiempo)
    {
        if (auxiliarDeConteo<cantidadDePreguntas)
        {
            //Debug.Log("Entro al yield primero...");
            yield return new WaitForSeconds(tiempo); // Espera 'tiempo' segundos
            bool isLastSentence = false;
            ObjetoConDialogue.GetComponent<DialogueManager>().NextSentence(out isLastSentence);
            auxiliarDeConteo +=1;
            StartCoroutine(EjecutarDespuesDeTiempo(tiempoParaDesaparecer));
        }
        else
        {
            //Debug.Log("Entro a detener...");
            yield return new WaitForSeconds(tiempo);
            auxiliarDeConteo = 1;
            ObjetoConDialogue.GetComponent<DialogueManager>().StopDialogue();
            
        }
        //barreraPrincipal.SetActive(false);


        //ObjetoConDialogue.GetComponent<DialogueManager>().StopDialogue();
        //barreraPrincipal.SetActive(true);
    }
}
