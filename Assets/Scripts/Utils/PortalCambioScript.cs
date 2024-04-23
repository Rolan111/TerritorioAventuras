using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCambioScript : MonoBehaviour
{
    public static GameObject portalCambio;

    // Start is called before the first frame update
    void Start()
    {
        portalCambio = GameObject.FindGameObjectWithTag("PortalCambio");
        portalCambio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
