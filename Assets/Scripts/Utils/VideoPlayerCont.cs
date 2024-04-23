using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerCont : MonoBehaviour
{
    public static int nivelCompletado = 0;
    private VideoPlayer videoPlayer;
    public VideoClip[] videoSource;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        int index = 0;
        switch (PlayerPrefs.GetString("UltimaEscena"))
        {
            case "3 Mundo 1Agua": index = 0; break;
            case "4 Mundo 2Centro": index = 1; break;
            case "5 Mundo 3PacíficoFolclor": index = 2; break;
            case "5 Mundo 4Norte": index = 3; break;
            case "5 Mundo 5OrienteTecnología": index = 4; break;
            case "6 Mundo 6 - EtniasPiamonte": index = 5; break;
            case "7 Mundo 7Sur": index = 6; break;
        }

        videoPlayer.clip = videoSource[index];
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
