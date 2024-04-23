using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbinaPlayAnim : MonoBehaviour
{

    private Animator animator;
    public static float puntos = 0;
    public static float turbinasActivas = 0;
    private bool hasPlayer = false;
    private bool isTurbinaActiva = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (animator != null && hasPlayer && !isTurbinaActiva) {
                if (puntos > 0)
                {
                    animator.SetTrigger("Run");
                    turbinasActivas++;
                    puntos--;
                    isTurbinaActiva = true;

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
