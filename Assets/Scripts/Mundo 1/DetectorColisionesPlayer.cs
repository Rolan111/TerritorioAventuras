using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorColisionesPlayer : MonoBehaviour
{
    //[SerializeField] public float cantidadPuntos;
    [SerializeField] private LogicaPuntajes[] logicaPuntajes;

    public ControlDeActivacion desactivarCanvas;//Para desactivar objetos en base a eventos
    public ControlDeActivacion activarCanvas2; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monedas"))
        {
            Debug.Log("El jugador ha chocado con una MONEDA.");
            logicaPuntajes[0].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/Aluminio"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Aluminio.");
            logicaPuntajes[1].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/Envases"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Envases.");
            logicaPuntajes[2].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Residuos/PapelYCarton"))
        {
            Debug.Log("El jugador ha chocado con un RESIDUO Papel y Cartón.");
            logicaPuntajes[3].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DisparadorPuzzle"))
        {
            Debug.Log("El jugador ha chocado con el DISPARADOR DEL PUZZLE.");
            //desactivarCanvas.DesactivarObjeto();
            activarCanvas2.ActivarObjeto();
            Time.timeScale = 0f; //Pausar juego
            //Liberamos el ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (other.CompareTag("PortalCambio"))
        {
            Debug.Log("El jugador ha chocado con el PORTAL DE CAMBIO0.");
            //captura ESCENA ACTUAL
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("VariableUltimaEscena", currentSceneIndex);
            //SceneManager.LoadScene("5 MundoFolclor");
            SceneManager.LoadScene("NivelCompleto");
        }
    }
}
