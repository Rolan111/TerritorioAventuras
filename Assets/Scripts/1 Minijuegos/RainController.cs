
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RainController : MonoBehaviour
{
    public GameObject rainPrefab;
    public float spawnInterval = 0.5f;
    public float fallSpeed = 1f;
    public int detectorDeIdioma = 1; //1. Misak, 2. Nasa, 3. Quechua

    //private string[] palabras = { "Buenos días", "Buenas tardes", "Buenas noches", "Por favor", "Gracias" };
    //private WordManager wordManager = new WordManager();

    private void Start()
    {
        //Inicializamos la clave valor que lleva el Botón que cambia
        PlayerPrefs.SetString("ValueIDButton", "ID1");
        StartCoroutine(SpawnRain());
    }

    IEnumerator SpawnRain()
    {
        var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager>();
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 60f, 0f); // Posición aleatoria en la parte superior de la pantalla
            var palabraConIdentificadorMisak = wordManager.GetRandomWordIdentifierMisak();
            var palabraConIdentificadorNasa = wordManager.GetRandomWordIdentifierNasa();
            var palabraConIdentificadorQuechua = wordManager.GetRandomWordIdentifierQuechua();

            GameObject newRain = Instantiate(rainPrefab, spawnPosition, Quaternion.identity);
            TextMeshPro wordDisplay = newRain.GetComponentInChildren<TextMeshPro>();
            


            if (wordDisplay != null)
            {
                switch (detectorDeIdioma)
                {
                    case 1:
                        wordDisplay.text = palabraConIdentificadorMisak.Key; //Se asigna la PALABRA a la HOJA en el IDIOMA elegido

                        //Para que el script correspondiente pueda recuperar el ID de la HOJA  y luego comparar con el del botón
                        newRain.GetComponentInChildren<RainClickHandler>().capturandoIdValueInspector = palabraConIdentificadorMisak.Value;
                        break;

                    case 2:
                        wordDisplay.text = palabraConIdentificadorNasa.Key;
                        newRain.GetComponentInChildren<RainClickHandler>().capturandoIdValueInspector = palabraConIdentificadorNasa.Value;
                        break;

                    case 3:
                        wordDisplay.text = palabraConIdentificadorQuechua.Key;
                        newRain.GetComponentInChildren<RainClickHandler>().capturandoIdValueInspector = palabraConIdentificadorQuechua.Value;
                        break;
                }

                //wordDisplay.text = palabraConIdentificadorMisak.Key; //Se asigna la PALABRA a la HOJA en el IDIOMA elegido
                
                ////Para que el script correspondiente pueda recuperar el ID de la HOJA  y luego comparar con el del botón
                //newRain.GetComponentInChildren<RainClickHandler>().capturandoIdValueInspector = palabraConIdentificadorMisak.Value; 
            }

            Rigidbody2D rb = newRain.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * fallSpeed;
            }


            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ModificandoDetectorDeIdioma(int seleccioneIdioma)
    {
        detectorDeIdioma = seleccioneIdioma;
    }

    public static void DestroyAllRainConSuScript()
    {
        ControladorReinicio[] rainControllers = FindObjectsOfType<ControladorReinicio>();
        foreach (ControladorReinicio rainController in rainControllers)
        {
            Destroy(rainController.gameObject);
        }
    }


}
