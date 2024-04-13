using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WordManager:MonoBehaviour
{

    public GameObject mensajeJuegoGanado;

    public Dictionary<string, string> palabrasIdentificadores = new Dictionary<string, string> {
        { "Buenos días", "ID1" },
        { "Buenas tardes", "ID2" },
        { "Buenas noches", "ID3" },
        { "Por favor", "ID4" },
        { "Gracias", "ID5" },
        { "Hola", "ID6" },
        { "Adiós", "ID7" }
    };

    //MISAK
    public Dictionary<string, string> palabrasIdentificadoresMisak = new Dictionary<string, string> {
        { "Kualøm ketre", "ID1" },
        { "Yantø mawan", "ID2" },
        { "Yantø yem køn", "ID3" },
        { "Tiusmanda", "ID4" },
        { "Unkua", "ID5" },
        { "Au", "ID6" },
        { "Aschap", "ID7" },
        { "Ya", "ID8" },
        { "Murik", "ID9" },
        { "Linchipic", "ID10" },
        { "Pesh", "ID11" },
        { "Piru", "ID12" },
        { "Pi", "ID13" }
    };

    //NASA
    public Dictionary<string, string> palabrasIdentificadoresNasa = new Dictionary<string, string> {
        { "Ma’ga Pe´te", "ID1" },
        { "Ma’ga Fxi’ze", "ID2" },
        { "Ma’ga Jxkuus", "ID3" },
        { "Meen", "ID4" },
        { "Pay", "ID5" },
        { "Ewcxa", "ID6" },
        { "Ki puutx uyunhaw", "ID7" },
        { "Yat", "ID8" },
        { "çxhaçxha", "ID9" },
        { "pkhaakhenxi", "ID10" },
        { "sek", "ID11" },
        { "kiwe", "ID12" },
        { "yu'", "ID13" }
    };

    //QUECHUA
    public Dictionary<string, string> palabrasIdentificadoresQuechua = new Dictionary<string, string> {
        { "Rimaykullayki", "ID1" },
        { "Rimaykullayki.", "ID2" },
        { "Rimaykullayki..", "ID3" },
        { "Ama hina", "ID4" },
        { "Riqsikuyki", "ID5" },
        { "Allinllachu", "ID6" },
        { "Tupanchikkama", "ID7" },
        { "Wasi", "ID8" },
        { "Sinchi", "ID9" },
        { "Mashipuray", "ID10" },
        { "Inti", "ID11" },
        { "Allpa", "ID12" },
        { "Yaku", "ID13" }
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


    public KeyValuePair<string, string> GetRandomWordIdentifierMisak()
    {
        if (palabrasIdentificadoresMisak.Count < 1)
        {
            mensajeJuegoGanado.SetActive(true);
        }
        int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresMisak.Count);
        var palabraIdentificador = palabrasIdentificadoresMisak.ElementAt(randomIndex);
        return palabraIdentificador;
    }


    public KeyValuePair<string, string> GetRandomWordIdentifierNasa()
    {
        if (palabrasIdentificadoresNasa.Count < 1)
        {
            mensajeJuegoGanado.SetActive(true);
        }
        int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresNasa.Count);
        var palabraIdentificador = palabrasIdentificadoresNasa.ElementAt(randomIndex);
        return palabraIdentificador;
    }

    public KeyValuePair<string, string> GetRandomWordIdentifierQuechua()
    {
        if (palabrasIdentificadoresQuechua.Count < 1)
        {
            mensajeJuegoGanado.SetActive(true);
        }
        int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresQuechua.Count);
        var palabraIdentificador = palabrasIdentificadoresQuechua.ElementAt(randomIndex);
        return palabraIdentificador;
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
        Debug.Log("La clave encontrada para ese valor es: " + key);

        palabrasIdentificadores.Remove(key);
        Debug.Log("Se elimino la clave: "+ key);

        //Elimina también en los OTROS IDIOMAS de una vez XD
        eliminarClaveValorMisak(valor);
        eliminarClaveValorNasa(valor);
        eliminarClaveValorQuechua(valor);
    }

    public void eliminarClaveValorMisak(string valor)
    {
        var key = palabrasIdentificadoresMisak.FirstOrDefault(x => x.Value == valor).Key;
        palabrasIdentificadoresMisak.Remove(key);
    }

    public void eliminarClaveValorNasa(string valor)
    {
        var key = palabrasIdentificadoresNasa.FirstOrDefault(x => x.Value == valor).Key;
        palabrasIdentificadoresNasa.Remove(key);
    }

    public void eliminarClaveValorQuechua(string valor)
    {
        var key = palabrasIdentificadoresQuechua.FirstOrDefault(x => x.Value == valor).Key;
        palabrasIdentificadoresQuechua.Remove(key);
    }

    //Usando HasWords Left
    /*
      if (!wordManager.HasWordsLeft())
        {
            // No hay más palabras, salir del bucle
            yield break; //sale del bucle WHILE que hay en el Rain Controller
        }  
        */

}

