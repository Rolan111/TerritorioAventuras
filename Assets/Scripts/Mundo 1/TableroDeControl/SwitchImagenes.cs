using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchImagenes : MonoBehaviour
{
    public GameObject[] background;
    private int index;

    void Start()
    {

        index = PlayerPrefs.GetInt("index", 0);
        SetActiveBackground();

    }

    public void Next()
    {

        index++;

        if (index >= background.Length) index = 0;

        Debug.Log("El index esta en: " + index);
        Debug.Log("El tamaño background esta en: " + background.Length);

        if (index == (background.Length-1))
        {
            Debug.Log("Esta es la ultima imagen");
        }

        SetActiveBackground();
        
    }

    public void Previous()
    {

        index--;

        if (index < 0)
            index = background.Length - 1;
        SetActiveBackground();

    }

    void SetActiveBackground()
    {


        

        for (int i = 0; i < background.Length; i++)
        {
            background[i].SetActive(i == index);
            
            
        }

        PlayerPrefs.SetInt("index", index);
        PlayerPrefs.Save();
    }
}
