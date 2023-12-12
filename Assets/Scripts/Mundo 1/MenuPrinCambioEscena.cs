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
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

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


}
