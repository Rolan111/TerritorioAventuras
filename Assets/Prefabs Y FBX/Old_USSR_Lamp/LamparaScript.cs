using HeneGames.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaScript : MonoBehaviour
{
    private bool hasPlayer = false;
    private Light light;
    private bool isLamparaActive = false;
    public static float lamparasActivas = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light != null && hasPlayer && TurbinaAguaPlayAnim.turbinaActivas >= 3 && !isLamparaActive)
            {
                light.enabled = true;
                isLamparaActive = true;
                lamparasActivas++;

                //eliminar dialogo
                DialogueManager dialog = GetComponent<DialogueManager>();
                dialog.StopDialogue();
                Destroy(dialog);

                //cumplir reto 1
                if (lamparasActivas >= 10)
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
