using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WordManager2:MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("ValueIDButton", "ID1");
    }
    public GameObject mensajeJuegoGanado;

    public Dictionary<string, string> palabrasIdentificadores = new Dictionary<string, string> {
        { "Marimba", "ID1" },
        { "Güiro", "ID2" },
        { "Tambora", "ID3" },
        { "Violines", "ID4" },
        { "Guitarra", "ID5" },
        { "Flauta", "ID6" },
        { "Saxofón", "ID7" },
        { "Maracas", "ID8" }
    };

    //MISAK
    public Dictionary<string, string> palabrasIdentificadoresMisak = new Dictionary<string, string> {
        { "Marimba", "ID1" },
        { "Güiro", "ID2" },
        { "Tambora", "ID3" },
        { "Violines", "ID4" },
        { "Guitarra", "ID5" },
        { "Flauta", "ID6" },
        { "Saxofón", "ID7" },
        { "Maracas", "ID8" }
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


    //public KeyValuePair<string, string> GetRandomWordIdentifierNasa()
    //{
    //    if (palabrasIdentificadoresNasa.Count < 1)
    //    {
    //        mensajeJuegoGanado.SetActive(true);
    //    }
    //    int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresNasa.Count);
    //    var palabraIdentificador = palabrasIdentificadoresNasa.ElementAt(randomIndex);
    //    return palabraIdentificador;
    //}

    //public KeyValuePair<string, string> GetRandomWordIdentifierQuechua()
    //{
    //    if (palabrasIdentificadoresQuechua.Count < 1)
    //    {
    //        mensajeJuegoGanado.SetActive(true);
    //    }
    //    int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresQuechua.Count);
    //    var palabraIdentificador = palabrasIdentificadoresQuechua.ElementAt(randomIndex);
    //    return palabraIdentificador;
    //}

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
        //eliminarClaveValorNasa(valor);
        //eliminarClaveValorQuechua(valor);
    }

    public void eliminarClaveValorMisak(string valor)
    {
        var key = palabrasIdentificadoresMisak.FirstOrDefault(x => x.Value == valor).Key;
        palabrasIdentificadoresMisak.Remove(key);
    }

    //public void eliminarClaveValorNasa(string valor)
    //{
    //    var key = palabrasIdentificadoresNasa.FirstOrDefault(x => x.Value == valor).Key;
    //    palabrasIdentificadoresNasa.Remove(key);
    //}

    //public void eliminarClaveValorQuechua(string valor)
    //{
    //    var key = palabrasIdentificadoresQuechua.FirstOrDefault(x => x.Value == valor).Key;
    //    palabrasIdentificadoresQuechua.Remove(key);
    //}

    //Usando HasWords Left
    /*
      if (!wordManager.HasWordsLeft())
        {
            // No hay más palabras, salir del bucle
            yield break; //sale del bucle WHILE que hay en el Rain Controller
        }  
        */

}

