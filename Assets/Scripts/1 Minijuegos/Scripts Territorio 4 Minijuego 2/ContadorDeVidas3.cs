using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContadorDeVidas3 : MonoBehaviour
{
    public TextMeshProUGUI contadorVidastextMeshProUGUI;
    public GameObject mensajeDeJuegoTerminado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menosVida()
    {
        int numVar = Int32.Parse(contadorVidastextMeshProUGUI.text);
        if (numVar==0)
        {
            //Time.timeScale = 0;
            mensajeDeJuegoTerminado.SetActive(true);
        }
        else
        {
            numVar -= 1;
            contadorVidastextMeshProUGUI.SetText(numVar.ToString());
        }
        
    }

    public void Reintentar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EtniasLluvia");
    }
}
