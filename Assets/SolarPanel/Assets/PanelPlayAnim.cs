using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PanelPlayAnim : MonoBehaviour
{
    private Animator animator;
    public static float panelActivas = 0;
    private bool hasPlayer = false;
    private bool isPanelActive = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (animator != null && hasPlayer && !isPanelActive)
            {
                animator.SetTrigger("Run");
                panelActivas++;
                isPanelActive = true;
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
