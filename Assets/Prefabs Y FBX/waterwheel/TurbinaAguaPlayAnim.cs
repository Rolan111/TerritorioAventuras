using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbinaAguaPlayAnim : MonoBehaviour
{
    private Animator animator;
    public static float puntos = 0;
    public static float turbinaActivas = 0;
    private bool hasPlayer = false;
    private bool isTurbinaActive = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (animator != null && hasPlayer && !isTurbinaActive)
            {
                if (puntos > 0)
                {
                    animator.SetTrigger("Run");
                    turbinaActivas++;
                    puntos--;
                    isTurbinaActive = true;

                    //eliminar dialogo
                    DialogueManager dialog = GetComponent<DialogueManager>();
                    dialog.StopDialogue();
                    Destroy(dialog);
                }
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
