using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeLvLScript : MonoBehaviour
{
    public static int tools = 0;
    public static int attempts = 1;
    public static int coins = 0;

    private VideoPlayer videoPlayer;
    public VideoClip[] videoSource;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();


        //inicial
        DateTime lastTimeClicked = DateTime.Parse(PlayerPrefs.GetString("dateStartLvl"));

        //actual
        TimeSpan difference = DateTime.UtcNow.Subtract(lastTimeClicked);


        int index = 0;
        string scene_name = PlayerPrefs.GetString("UltimaEscena");
        switch (scene_name)
        {
            case "3 Mundo 1Agua": index = 0; break;
            case "4 Mundo 2Centro": index = 1; break;
            case "5 Mundo 3PacíficoFolclor": index = 2; break;
            case "5 Mundo 4Norte": index = 3; break;
            case "5 Mundo 5OrienteTecnología": index = 4; break;
            case "6 Mundo 6 - EtniasPiamonte": index = 5; break;
            case "7 Mundo 7Sur": index = 6; break;
        }

        //actulizar todos los demas niveles a 0
        GameStateApiLocal.UpdateActualGameByIdUser(UserApiLocal.UserLogin.id);

        //consultar lvl descripcion
        LevelDescriptionModel description = LevelDescriptionApiLocal.FindBySceneName(scene_name);

        //crear nuevo registro de nuevo nivel
        GameStateModel newGameState = new GameStateModel();
        newGameState.id_user = UserApiLocal.UserLogin.id;
        newGameState.id_avatar = 1;
        newGameState.id_level_description = description.id;
        newGameState.attempts = attempts.ToString();
        newGameState.coins = coins.ToString();
        newGameState.tools = tools;
        newGameState.game_time = difference.Minutes.ToString();
        GameStateApiLocal.Save(newGameState);

        //play video
        videoPlayer.clip = videoSource[index];
        videoPlayer.Play();

        //resetear valores para el siguiente nivel
        tools = 0;
        attempts = 1;
        coins = 0;
    }

    public static void FinalizarNivel()
    {
        //captura ESCENA ACTUAL
        var currentSceneIndex = SceneManager.GetActiveScene();
        GameObject.Find("ControladorPanelesTableroControl").GetComponent<ControladorTableroControl>().MostrarInsigniaYNivel(currentSceneIndex.buildIndex);
        //ControladorTableroControl.mostrarInsigniaYNivel(currentSceneIndex.buildIndex);
        PlayerPrefs.SetInt("VariableUltimaEscena", currentSceneIndex.buildIndex);
        PlayerPrefs.SetString("UltimaEscena", currentSceneIndex.name);
        SceneManager.LoadScene("NivelCompleto");
    }

    //OPCION ACTIVANDO padre e hijos, funciona cuando los objetos están activos y visibles dentro de la escena
        //La otra opción está en ControladorTableroControl
    public static void GestionTableroControl(int currentScene)//Se procede a mostrar el nivel en el que va y las insignias ganadas
    {
        // Buscar el objeto padre por su nombre
        GameObject objetoPadreInsignias = GameObject.Find("GridCandadosInsignias");
        GameObject objetoPadreNiveles = GameObject.Find("GridCandadoNiveles");

        //Comprobamos que los objetos SI EXISTAN
        if (objetoPadreInsignias != null && objetoPadreNiveles != null)
        {

            // Buscar el hijo por su nombre dentro del objeto padre
            Transform hijo = objetoPadreInsignias.transform.Find("imgCandado1");
            

            if (hijo != null)
            {
                Debug.Log("Hijo encontrado: " + hijo.name);
                // Puedes realizar operaciones con el hijo aquí
                hijo.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("No se encontró el hijo con el nombre especificado.");
            }
        }
        else
        {
            Debug.Log("No se encontró el objeto padre con el nombre especificado.");
        }

        switch (currentScene)
        {
            case 3:
                Console.WriteLine("The number is 1");
                break;
            case 4:
                Console.WriteLine("The number is 2");
                break;
            case 5:
                Console.WriteLine("The number is 1");
                break;
            case 6:
                Console.WriteLine("The number is 1");
                break;
            case 7:
                Console.WriteLine("The number is 1");
                break;
            case 8:
                Console.WriteLine("The number is 1");
                break;
            case 9:
                Console.WriteLine("The number is 1");
                break;
            default:
                Console.WriteLine("The number is neither 1 nor 2");
                break;
        }
    }

    public static void IniciarConteoTiempo()
    {
        //guardar valor de tiempo desde el inicio
        PlayerPrefs.SetString("dateStartLvl", DateTime.UtcNow.ToString());
    }
}
