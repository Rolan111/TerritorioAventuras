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
            TurbinaAguaPlayAnim.turbinaActivas = 3;

            if (light != null && hasPlayer && TurbinaAguaPlayAnim.turbinaActivas >= 3 && !isLamparaActive)
            {
                light.enabled = true;
                isLamparaActive = true;
                lamparasActivas++;
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
