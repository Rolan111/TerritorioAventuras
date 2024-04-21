using SUPERCharacter;
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
    public GameObject efectoPinzaActivar;
    public GameObject pinzaSobreJugador;
    public GameObject jugadorParaPausar;

    //Detectar Animator para detener
    public Animator animator;

    //Detectar doble click
    public float doubleClickTimeThreshold = 0.2f; // Puedes ajustar este valor según tu necesidad
    private float lastClickTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//Cuando se presiona Escape, para que se pueda interactuar con el tablero
        {
            //Liberar ratón
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Detectar doble click
        if (Input.GetMouseButtonDown(0)) // Aquí asumimos el click izquierdo del ratón, puedes cambiarlo según tu necesidad
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickTimeThreshold)
            {
                // Doble click detectado
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            lastClickTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.CompareTag("Monedas"))
        {
            Debug.Log("El jugador ha chocado con una MONEDA.");
            logicaPuntajes[0].ContadorPuntajes(1);
            Destroy(other.gameObject);
        }

        //Residuos
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
        //*****

        else if (other.CompareTag("DisparadorPuzzle"))//Actualmente activo en el del Bote
        {
            
            Debug.Log("El jugador ha chocado con el DISPARADOR DEL PUZZLE.");
            //desactivarCanvas.DesactivarObjeto();
            activarCanvas2.ActivarObjeto();
            //Time.timeScale = 0f; //Pausar juego
            // Impide que el personaje se desplace con fuerza


            //Pausar solo el movimeinto del jugador


            jugadorParaPausar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false;


            //animator.enabled = false;
            StartCoroutine(EsperarYContinuarCoroutine());

            IEnumerator EsperarYContinuarCoroutine()
            {

                yield return new WaitForSeconds(2f); // Espera 3 segundos

                //jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = true;
                jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = true;
                yield return new WaitForSeconds(2f); // Espera 3 segundos
                jugadorParaPausar.GetComponent<SUPERCharacterAIO>().enabled = false;

            }




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
        else if (other.CompareTag("Pinza"))
        {
            // Destruye el objeto con el que chocamos
            Destroy(other.gameObject);
            //GameObject.FindGameObjectsWithTag("EfectoDesaparecerPinza");
            efectoPinzaActivar.SetActive(true);
            pinzaSobreJugador.SetActive(true);
            Invoke("DestruirObjeto", 1.5f);
        }
        else if (other.CompareTag("Agua"))
        {
            SceneManager.LoadScene("5 Mundo 5OrienteTecnología");
        }


    }

    //FUNCIONES ADICIONALES
    void DestruirObjeto()
    {
        DestroyImmediate(efectoPinzaActivar);
    }

}
