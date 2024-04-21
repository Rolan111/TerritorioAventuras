using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbinaPlayAnim : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetTrigger("Run");
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                animator.SetTrigger("Stop");
            }
        }
    }
}
