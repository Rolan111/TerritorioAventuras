using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class WordManager4:MonoBehaviour
{
    

    private void Start() 
    {
        GameObject palabraEnBoton = GameObject.Find("txtBoton1");

        //Colocamos el primer dato por defecto aleatorio al botón o en este caso a la pregunta
        var palabraIdentificador = GetRandomWordIdentifier();
        palabraEnBoton.GetComponent<TextMeshProUGUI>().SetText(palabraIdentificador.Key);
        PlayerPrefs.SetString("ValueIDButton", palabraIdentificador.Value);
    }

    public GameObject mensajeJuegoGanado;

    public Dictionary<string, string> palabrasIdentificadores = new Dictionary<string, string> {

        { "1.\tVisitas el domingo a un amigo y encuentras en el camino que hay 8 gallinas, 9 vacas, 7 patos," +
            " 4 caballos, 3 perros, 2 autos, 3 motocicletas y 2 gatos. Ahora identifica cual operación básica" +
            " te sirve para resolver el problema ¿Cuántos animales encontraste en el camino?", "ID1" },

        { "2.\tLa Mamá de José lo envió al mercado para que comprara 20 naranjas, lastimosamente no se dio" +
            " cuenta que la bolsa en que las empacó estaba rota, y en el camino se le cayeron 7 naranjas. " +
            "¿Cuándo José llegó a la casa, con cuantas naranjas llegó a la casa?  ", "ID2" },

        { "3.\tJorge es un niño de 7 años que vive en El Bordo y debe ir con sus padres a un examen médico" +
            " en Popayán, en el bus en el que viajan la velocidad con la que va es 80 kilómetros por hora" +
            " recorrida, su recorrido fue de 3 horas. ¿Cuántos kilómetros en total recorrió el bus?", "ID3" },

        { "4.\tEn la iglesia del pueblo hay 120 sillas, ubicadas en grupos de 6 líneas. Sabes que cada línea" +
            " tiene la misma cantidad de sillas. Una amiga te consulta: ¿Cuantas sillas había en cada grupo?" +
            " \r\nSelecciona la operación que vas a utilizar\r\n", "ID4" },

        { "5.\tEn el recorrido al bosque el grado 5 de primaria recogió 120 moras, se decide hacer unos" +
            " pasteles para compartir con los otros cursos, se decide utilizar 8 moras para hacer cada pastel." +
            " La profesora pregunta ¿Cuántos pasteles se pudieron hacer?", "ID5" },
    };


    //                          ***************** MÉTODOS PARA OBTENER LAS PALABRAS *************************

    public KeyValuePair<string, string> GetRandomWordIdentifier()
    {
        //Evaluamos primero que hayan palabras en el diccionario
        if (palabrasIdentificadores.Count < 1)
        {
            mensajeJuegoGanado.SetActive(true);
        }

        int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadores.Count);
        var palabraIdentificador = palabrasIdentificadores.ElementAt(randomIndex);
        //palabrasIdentificadores.Remove(palabraIdentificador.Key); // Para evitar repeticiones, puedes comentar esta línea si permites repeticiones
        return palabraIdentificador;
    }

    public void CambioDePregunta()//Se puede llamar desde CUALQUIER LUGAR
    {
        //var wordManager = GameObject.Find("Diccionario").GetComponent<WordManager>();
        GameObject palabraEnBoton = GameObject.Find("txtBoton1");
        //var palabraIdentificador = wordManager.GetRandomWordIdentifier();
        var palabraIdentificador = GetRandomWordIdentifier();

        //Para la PR'OXIMA
        palabraEnBoton.GetComponent<TextMeshProUGUI>().SetText(palabraIdentificador.Key); //Esto es para la SIGUIENTE ITERACI'ON

        PlayerPrefs.SetString("ValueIDButton", palabraIdentificador.Value);
        //        *************************
    }

    public bool HasWordsLeft() // La función HasWordsLeft() es útil para verificar si todavía quedan palabras en el WordManager antes de crear una nueva hoja de lluvia.
    {
        return palabrasIdentificadores.Count > 0;
    }



    //                                       ************** ELIMINACIÓN DE DATOS **********************

    public void eliminarClaveValor(string valor)
    {
        //Primero eliminamos en ESPAÑOL: Buscamos la Clave en base al valor que se nos presenta
        var key = palabrasIdentificadores.FirstOrDefault(x => x.Value == valor).Key;
        //Debug.Log("La clave encontrada para ese valor es: " + key);

        palabrasIdentificadores.Remove(key);
        Debug.Log("Se elimino la clave: "+ key);

        //Elimina también en los OTROS IDIOMAS de una vez XD
        //eliminarClaveValorMisak(valor);
        //eliminarClaveValorNasa(valor);
        //eliminarClaveValorQuechua(valor);
    }

}

