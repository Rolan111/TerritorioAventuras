using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcsScript : MonoBehaviour
{
    private bool hasPlayer = false;
    private Light light;
    private bool isPCActive = false;
    public static float pcActivas = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light != null && hasPlayer && PanelPlayAnim.panelActivas >= 8 && !isPCActive)
            {
                light.enabled = true;
                isPCActive = true;
                PcsScript.pcActivas++;
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
