using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroondasScript : MonoBehaviour
{
    private bool isMicroActive = false;
    private bool hasPlayer = false;
    private Light light;
    public static float microondasActivas = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light != null && hasPlayer && TurbinaPlayAnim.turbinasActivas >= 3 && !isMicroActive)
            {
                light.enabled = true;
                isMicroActive = true;
                MicroondasScript.microondasActivas++;

                //eliminar dialogo
                DialogueManager dialog = GetComponent<DialogueManager>();
                dialog.StopDialogue();
                Destroy(dialog);

                //cumplir reto 1
                if (microondasActivas >= 10)
                {
                    //cumplio el reto
                    GameObject.Find("RetoFin").GetComponent<DisparadorDialogueSimple>().métodoDispararDiálogo();
                }

                // validar si todo en el lvl 5 esta completo
                DetectorColisionesPlayer.validarNivel5();
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
