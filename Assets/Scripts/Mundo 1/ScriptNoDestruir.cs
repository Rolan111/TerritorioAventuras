using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class ScriptNoDestruir : MonoBehaviour //No destruye y a la vez se asegura que haya una
                                              //sola instancia del objeto
{
    private static ScriptNoDestruir instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Al cambiar de escena, verifica si "Cubo" ya existe.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject existingCubo = GameObject.Find("CanvasTableroControl");
        if (existingCubo != null && existingCubo != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
