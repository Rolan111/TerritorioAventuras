using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroondasScript : MonoBehaviour
{

    private bool hasPlayer = false;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light != null && hasPlayer && TurbinaPlayAnim.turbinasActivas >= 3)
            {
                light.enabled = true;
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
