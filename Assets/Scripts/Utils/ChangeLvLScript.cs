using System;
using System.Collections;
using System.Collections.Generic;
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
            case "5 Mundo 3Pac�ficoFolclor": index = 2; break;
            case "5 Mundo 4Norte": index = 3; break;
            case "5 Mundo 5OrienteTecnolog�a": index = 4; break;
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
        PlayerPrefs.SetInt("VariableUltimaEscena", currentSceneIndex.buildIndex);
        PlayerPrefs.SetString("UltimaEscena", currentSceneIndex.name);
        SceneManager.LoadScene("NivelCompleto");
    }

    public static void IniciarConteoTiempo()
    {
        //guardar valor de tiempo desde el inicio
        PlayerPrefs.SetString("dateStartLvl", DateTime.UtcNow.ToString());
    }
}
