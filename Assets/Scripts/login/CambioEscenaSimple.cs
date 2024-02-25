using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaSimple : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        //SceneManager.LoadScene("1.5 VideoIntroducción");
        SceneManager.LoadScene(nombreEscena);
    }
}
