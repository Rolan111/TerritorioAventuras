using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{

    public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("El estado es: "+ playerMove.puedoSaltar);
    }

    private void OnTriggerStay(Collider other)
    {
        playerMove.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.puedoSaltar = false;
    }
}
