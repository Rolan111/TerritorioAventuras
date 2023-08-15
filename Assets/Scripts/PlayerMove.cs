using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 150f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Salte", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            animator.SetBool("TocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }

        //Debug.Log("Puedo saltar esta en: "+puedoSaltar);
        
    }

    public void EstoyCayendo()
    {
        animator.SetBool("TocoSuelo", false);
        animator.SetBool("Salte", false);
    }
}
