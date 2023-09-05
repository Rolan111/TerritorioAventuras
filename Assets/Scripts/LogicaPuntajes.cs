using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class LogicaPuntajes : MonoBehaviour
{

    private float puntos;
    private TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //puntos += Time.deltaTime;
        textMeshProUGUI.text = puntos.ToString("0");
    }

    public void ContadorPuntajes(float puntosEntradas) //sirve para todos los objetos del canvas
    {
        puntos += puntosEntradas;
    }

}
