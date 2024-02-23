using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroduccionControladorVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += VideoTerminado;
        ReproducirVideo();
    }

    void ReproducirVideo()
    {
        videoPlayer.Play();
    }

    public void VideoTerminado(VideoPlayer vp)
    {

        SceneManager.LoadScene("2 MenuPrincipal");
    }
}
