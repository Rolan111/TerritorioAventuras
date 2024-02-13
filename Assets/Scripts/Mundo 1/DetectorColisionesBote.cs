using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorColisionesBote : MonoBehaviour
{
    //[SerializeField] public float cantidadPuntos;
    [SerializeField] private LogicaPuntajes[] logicaPuntajes;

    public GameObject[] activarResiduo;
    [SerializeField] private GameObject actDescCanvas2;
    public GameObject jugadorParaPausar;

    public AudioSource audioSource;
    public AudioClip audioColisionBasuras;

    private void OnTriggerEnter(Collider other)
    {

        EjecutarSonido(audioColisionBasuras);

        //Residuos
        if (other.CompareTag("Residuos/Aluminio"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Aluminio.");
            logicaPuntajes[1].ContadorPuntajes(1);
            Destroy(other.gameObject);
            activarResiduo[0].SetActive(true);
        }
        else if (other.CompareTag("Residuos/Envases"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Envases.");
            logicaPuntajes[2].ContadorPuntajes(1);

            if (other.name == "BotellaCerveza_01 ")
            {
                Debug.Log("El bote ha colisionado con la cerveza");
                activarResiduo[1].SetActive(true);
            }
            else
            {
                activarResiduo[2].SetActive(true);
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/PapelYCarton"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Papel y Cartón.");
            logicaPuntajes[3].ContadorPuntajes(1);
       

            if (other.name == "PapelArrugado_01 ")
            {
                activarResiduo[3].SetActive(true);
            }
            
            if (other.name == "PapelArrugado_02")
            {
                activarResiduo[4].SetActive(true);
            }
            
            if(other.name == "VasoDesechable_01")
            {
                activarResiduo[5].SetActive(true);
            }

            if (other.name == "VasoDesechable_02")
            {
                activarResiduo[6].SetActive(true);
            }

            Destroy(other.gameObject);

        }

        else if (other.CompareTag("DisparadorPuzzle"))
        {
            Debug.Log("El jugador ha chocado con el DISPARADOR DEL PUZZLE.");
            //desactivarCanvas.DesactivarObjeto();
            actDescCanvas2.SetActive(true);
            //Time.timeScale = 0f; //Pausar juego
            jugadorParaPausar.GetComponent<ControlBote>().enabled = false; //Pausar solo el movimeinto del jugador

            //Liberamos el ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //*****


    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

}
