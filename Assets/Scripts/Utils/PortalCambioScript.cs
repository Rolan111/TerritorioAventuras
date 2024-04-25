using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCambioScript : MonoBehaviour
{
    public static GameObject portalCambio;

    // Start is called before the first frame update
    void Start()
    {
        GameStateModel gameState = GameStateApiLocal.FindActualGameByIdUser(UserApiLocal.UserLogin.id);
        if (gameState != null)
        {
            portalCambio = GameObject.FindGameObjectWithTag("PortalCambio");
            portalCambio.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
