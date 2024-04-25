using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrinCambioEscena : MonoBehaviour
{

    public static MenuPrinCambioEscena instance;

    public AudioSource audioSource; // Referencia al AudioSource que reproducirá el sonido
    public AudioClip sonido; // Variable para almacenar el audio a reproducir

    // Esta función se llama cuando se instancian los scripts
    void Awake()
    {
        // Inicialización de variables o referencias aquí
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


    // Método que se ejecuta al presionar el botón
    public void ReproducirSonido2()
    {
        audioSource.PlayOneShot(sonido); // Reproducir el sonido una vez
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void CambiarEscena2()
    {
        ChangeLvLScript.IniciarConteoTiempo();

        int receivedVariableUltimaEscena = PlayerPrefs.GetInt("VariableUltimaEscena");
        int siguienteEscena = receivedVariableUltimaEscena + 1;
        SceneManager.LoadScene(siguienteEscena);
    }

    public void FuncionCerrarJuego()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        // Obtiene el índice de la escena actual
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
