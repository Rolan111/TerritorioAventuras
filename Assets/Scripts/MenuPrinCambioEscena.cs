using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrinCambioEscena : MonoBehaviour
{
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
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena actual, lo que reinicia la escena
        SceneManager.LoadScene(currentSceneIndex);
    }


}
