using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrinCambioEscena : MonoBehaviour
{

    public static MenuPrinCambioEscena instance;

    public AudioSource audioSource; // Referencia al AudioSource que reproducir� el sonido
    public AudioClip sonido; // Variable para almacenar el audio a reproducir

    // Esta funci�n se llama cuando se instancian los scripts
    void Awake()
    {
        // Inicializaci�n de variables o referencias aqu�
        // Garantiza que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();

        ValidarMenuPrincipal();
    }


    // M�todo que se ejecuta al presionar el bot�n
    public void ReproducirSonido2()
    {
        audioSource.PlayOneShot(sonido); // Reproducir el sonido una vez
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void CambiarEscena(string nombreEscena)//M�todo simple para usar inidiviudalmetne al nombre de la escena que se quiere cambiar
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void CambiarEscena2()//M�todo para cambiar de escena en base al identificador entero del panel "Build Settings"
    {
        ChangeLvLScript.IniciarConteoTiempo();

        //PRIMER M�TODO - Capturar el index de la escena mediante PlayerPrefs
        int receivedVariableUltimaEscena = PlayerPrefs.GetInt("VariableUltimaEscena");
        int siguienteEscena = receivedVariableUltimaEscena + 1;
        SceneManager.LoadScene(siguienteEscena);
    }

    //public void CambiarEscena3()
    //{
    //    //SEGUNDO M�TODO - Capturar el index de la escena mediante el Build index del Build Settings
    //    // Este m�todo puede que no funcione ya que captura la escena actual y se necesita la �ltima escena
    //    //Ensayar en cada mundo actualizar el player prefs de VariableUltimaEscena

    //    //// Obtener la escena activa actualmente
    //    //Scene currentScene = SceneManager.GetActiveScene();

    //    //// Obtener el �ndice de la escena activa
    //    //int receivedVariableUltimaEscena = currentScene.buildIndex;
    //}

    public void FuncionCerrarJuego()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        // Obtiene el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena actual, lo que reinicia la escena
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ValidarMenuPrincipal()
    {
        //validar continuar si paso nivel
        GameObject btn_Continuar = GameObject.Find("Btn_Continuar");
        if (btn_Continuar != null)
        {
            GameStateModel gameState = GameStateApiLocal.FindActualGameByIdUser(UserApiLocal.UserLogin.id);
            if (gameState == null)
            {
                btn_Continuar.SetActive(false);
            }
        }

        //validar tabler para docente
        GameObject btn_tablero_seguimiento = GameObject.Find("Btn_TableroSeguimiento");
        if (btn_tablero_seguimiento != null)
        {
            if (UserApiLocal.UserLogin.id_rol == RolApiLocal.ROL_ESTUDIANTE)
            {
                btn_tablero_seguimiento.SetActive(false);
            }
        }
    }

    public void NuevoJuego()
    {
        ChangeLvLScript.IniciarConteoTiempo();

        //actualizar todos los demas a 0
        GameStateApiLocal.UpdateActualGameByIdUser(UserApiLocal.UserLogin.id);

        //obtener nivel 1
        LevelDescriptionModel levelChallenge = LevelDescriptionApiLocal.FindById(1);
        CambiarEscena(levelChallenge.scene_name);
    }

    public void ContinuarJuego()
    {
        ChangeLvLScript.IniciarConteoTiempo();

        //obtener actual game state
        GameStateModel gameState = GameStateApiLocal.FindActualGameByIdUser(UserApiLocal.UserLogin.id);

        //obtener nombre de la escena actual + 1 para la siguiente
        LevelDescriptionModel nextLevel = LevelDescriptionApiLocal.FindById(gameState.id_level_description + 1);
        CambiarEscena(nextLevel.scene_name);
    }
}
