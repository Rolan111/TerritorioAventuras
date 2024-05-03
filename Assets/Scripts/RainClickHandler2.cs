
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainClickHandler2 : MonoBehaviour
{
    public GameObject manejadorCoincidenciaCorrecta;
    public GameObject veloVerde;

    public string capturandoIdValueInspector; //EN NUBE (En el idioma que se haya elegido) //PlayerPrefs, En BOT�N

    public void OnMouseDown()
    {
        Debug.Log("Se ha presionado el bot�n");

        // Buscar un objeto por su nombre
        GameObject palabraEnBoton = GameObject.Find("txtBoton1");
        GameObject contadorDeVidas = GameObject.Find("txtContadorDeVidas");
        var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager2>();

        

        // Verificar si se encontr� el objeto, es decir el bot�n en la Herarchy
        if (palabraEnBoton != null) //En este caso la palabra est� oculta
        {
            if (capturandoIdValueInspector == PlayerPrefs.GetString("ValueIDButton")) //SON IGUALES
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto2>().Correcto();
                wordManager.eliminarClaveValor(capturandoIdValueInspector);//Elimina en todos los idiomas
                veloVerde.SetActive(true);
                
                //Destroy(gameObject);
            }
            else
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto2>().Incorrecto();
                contadorDeVidas.GetComponent<ContadorDeVidas2>().menosVida();
            }

            var palabraIdentificador = wordManager.GetRandomWordIdentifier();

            Debug.Log("El IDentificador capturado en el instrumento es: " + capturandoIdValueInspector);
            Debug.Log("El IDentificador capturado anterior para el BOTON KEY es: " + PlayerPrefs.GetString("ValueIDButton"));

            //Para la PR'OXIMA
            palabraEnBoton.GetComponent<TextMeshProUGUI>().SetText(palabraIdentificador.Key); //Esto es para la SIGUIENTE ITERACI'ON

            //Buscamos y reproducimos el sonido
            GameObject.Find("SonidosInstrumentos").GetComponent<SoundManager>().ReproducirSonidoInstrumento(palabraIdentificador.Value);

            PlayerPrefs.SetString("ValueIDButton", palabraIdentificador.Value);
        }
        else
        {
            Debug.Log("No se encontr� el objeto con el nombre 'MiObjeto'");
        }



        // Aqu� puedes agregar cualquier acci�n que desees al hacer clic en la lluvia
        //Destroy(gameObject); // Por ejemplo, destruir la imagen al hacer clic en ella
    }
}
