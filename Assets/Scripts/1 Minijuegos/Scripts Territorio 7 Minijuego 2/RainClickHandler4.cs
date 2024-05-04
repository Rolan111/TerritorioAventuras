
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainClickHandler4 : MonoBehaviour
{
    public GameObject manejadorCoincidenciaCorrecta;
    public GameObject veloVerde;

    public string capturandoIdValueInspector; //En inspector (En el idioma que se haya elegido) //PlayerPrefs, En BOT�N

    public void OnMouseDown()
    {
        // Buscar un objeto por su nombre
        GameObject palabraEnBoton = GameObject.Find("txtBoton1");
        GameObject contadorDeVidas = GameObject.Find("txtContadorDeVidas");
        var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager4>();
        string manejadorDeCoincidencia; //Se encontr� la necesidad para este ejercicio de colocar un manejador de
                                        //coinicidencia ya que se tienen 5 frases pero solo 4 botones de opciones de respuesta

        // Verificar si se encontr� el objeto, es decir el bot�n en la Herarchy
        if (palabraEnBoton != null) //En este caso la palabra est� oculta
        {
            //A manejadorDeCoincidencia se le asigna lo que devuelta el m�todo para que solo se quede con los 4 valores correspondientes
            manejadorDeCoincidencia= GestionDeCoincidencia(PlayerPrefs.GetString("ValueIDButton"));

            if (capturandoIdValueInspector == manejadorDeCoincidencia) //SON IGUALES
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto4>().Correcto();
                //wordManager.eliminarClaveValor(capturandoIdValueInspector);//Elimina una clave, frase o p�rrafo, cuando no queda ninguna el jugador GANA
                veloVerde.SetActive(true);
                
                //NOTA: En este caso pasamos lo que capture en el PlayerPrefs para hacer coincidir correctamente
                //  ya que se contienen 5 frases en el diccionario pero solo 4 botones de opciones de respuesta
                GameObject.Find("ImageManager").GetComponent<ImageManager2>().AmpliarImagen(PlayerPrefs.GetString("ValueIDButton"));
                //Destroy(gameObject);
            }
            else
            {
                manejadorCoincidenciaCorrecta.GetComponent<ManejoCorrectoIncorrecto4>().Incorrecto();
                //La resta de vidas se hace directamente en el script y m�todo anterior

                //contadorDeVidas.GetComponent<ContadorDeVidas>().menosVida();
                wordManager.CambioDePregunta();//cambia de pregunta sin eliminar la clave-valor
            }

            ////**** L�gica para el CAMBIO DE FRASE ****
            //var palabraIdentificador = wordManager.GetRandomWordIdentifier();

            ////Debug.Log("El IDentificador capturado en el instrumento es: " + capturandoIdValueInspector);
            ////Debug.Log("El IDentificador capturado anterior para el BOTON KEY es: " + PlayerPrefs.GetString("ValueIDButton"));

            ////Para la PR'OXIMA
            //palabraEnBoton.GetComponent<TextMeshProUGUI>().SetText(palabraIdentificador.Key); //Esto es para la SIGUIENTE ITERACI'ON

            //PlayerPrefs.SetString("ValueIDButton", palabraIdentificador.Value);
            ////        *************************
        }
        else
        {
            Debug.Log("No se encontr� el objeto con el nombre 'MiObjeto'");
        }



        // Aqu� puedes agregar cualquier acci�n que desees al hacer clic en la lluvia
        //Destroy(gameObject); // Por ejemplo, destruir la imagen al hacer clic en ella
    }

    public string GestionDeCoincidencia(string coincidenciaABoton)
    {
        switch (coincidenciaABoton)
        {
            case "ID1":
                coincidenciaABoton = "ID1";
                break;
            case "ID2":
                coincidenciaABoton = "ID2";
                break;
            case "ID3":
                coincidenciaABoton = "ID3";
                break;
            case "ID4":
                coincidenciaABoton = "ID4";
                break;
            case "ID5":
                coincidenciaABoton = "ID4";
                break;
            // more cases can follow
            default:
                // code to execute if expression doesn't match any case
                break;
        }
        return coincidenciaABoton;
    }

    public void EliminarClaveValorManualmente()
    {
        var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager4>();
        wordManager.eliminarClaveValor(capturandoIdValueInspector);//Elimina una clave, frase o p�rrafo, cuando no queda ninguna el jugador GANA
    }
}
