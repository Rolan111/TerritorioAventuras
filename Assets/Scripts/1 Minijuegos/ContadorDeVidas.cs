using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContadorDeVidas : MonoBehaviour
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
            //mensajeDeJuegoTerminado.GetComponent<AudioSource>().Play();
            //RainController.DestroyAllRainConSuScript();//destruye todos los clones de las hojas
        }
        else
        {
            numVar -= 1;
            contadorVidastextMeshProUGUI.SetText(numVar.ToString());
        }
        
    }

    public void LlenarVida()
    {
        contadorVidastextMeshProUGUI.SetText("5");
    }

    public void Reintentar()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("EtniasLluvia");
    }
}