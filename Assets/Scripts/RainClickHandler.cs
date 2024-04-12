
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainClickHandler : MonoBehaviour
{
    public GameObject manejadorCoincidenciaCorrecta;

    //private string[] palabras = { "Buenos días", "Buenas tardes", "Buenas noches", "Por favor", "Gracias" };
    //private WordManager wordManager = new WordManager();
    public string capturandoIdValueInspector; //EN NUBE (En el idioma que se haya elegido) //PlayerPrefs, En BOTÓN

    private void OnMouseDown()
    {
        
        TextMeshPro palabraEnHoja = GetComponentInChildren<TextMeshPro>();

        // Buscar un objeto por su nombre
        GameObject palabraEnBoton = GameObject.Find("txtBoton1");
        GameObject contadorDeVidas = GameObject.Find("txtContadorDeVidas");
        var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager>();

        // Verificar si se encontró el objeto
        if (palabraEnBoton != null)
        {
            if (capturandoIdValueInspector == PlayerPrefs.GetString("ValueIDButton")) //SON IGUALES
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto>().Correcto();
                wordManager.eliminarClaveValor(capturandoIdValueInspector);//Elimina en todos los idiomas
            }
            else
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto>().Incorrecto();
                contadorDeVidas.GetComponent<ContadorDeVidas>().menosVida();
            }

            var palabraIdentificador = wordManager.GetRandomWordIdentifier();

            Debug.Log("El IDentificador capturado de la hoja en MISAK es: " + capturandoIdValueInspector);
            Debug.Log("El IDentificador capturado anterior para el BOTON KEY es: " + PlayerPrefs.GetString("ValueIDButton"));

            //Para la PR'OXIMA
            palabraEnBoton.GetComponent<TextMeshProUGUI>().SetText(palabraIdentificador.Key); //Esto es para la SIGUIENTE ITERACI'ON
            PlayerPrefs.SetString("ValueIDButton", palabraIdentificador.Value);
        }
        else
        {
            Debug.Log("No se encontró el objeto con el nombre 'MiObjeto'");
        }



        // Aquí puedes agregar cualquier acción que desees al hacer clic en la lluvia
        Destroy(gameObject); // Por ejemplo, destruir la imagen al hacer clic en ella
    }
}
