using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class WordManager3:MonoBehaviour
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

        { "Declarado por la UNESCO como Reserva de la Biosfera en 1979, es una zona volcánica y lo refleja" +
            " tanto en sus numerosas fuentes azufradas como en su nombre, que en lengua quechua significa" +
            " “montaña de fuego”. Allí nacen los principales ríos de Colombia: Magdalena, Cauca, Patía y Caquetá" +
            " y también 30 lagunas tranquilas y claras, ideales para la contemplación." +
            "\r\nTomado de: https://www.parquesnacionales.gov.co/nuestros-parques/pnn-purace/\r\n", "ID1" },

        { "Puente histórico del centro de Popayán con 12 arcos. El origen del nombre se debe a que la zona" +
            " se encontraba con una inclinación importante, lo que hacía obligatorio bajar la cabeza, naciendo" +
            " el nombre del puente.\r\nSe inauguró en julio de 1873 y a partir de entonces se ha convertido en" +
            " uno de los puentes más populares de la zona, un lugar al que suelen acudir los visitantes." +
            "\r\nTomado de: https://locationcolombia.com/locacion/puente-del-humilladero/\r\n", "ID2" },

        { "Fundado en el año 1936 por el biólogo Federico Carlos Lehmann Valencia, es un importante centro de" +
            " investigación, exhibición y proyección a la comunidad universitaria y ciudadanía en general, por" +
            " cuanto estimula el conocimiento de las Ciencias Naturales tanto a estudiantes de escuelas," +
            " colegios y universidades como a investigadores y otros profesionales de Popayán, el Cauca," +
            " Colombia y del extranjero" +
            "\r\nTomado de: https://facultades.unicauca.edu.co/museonatural/quienes-somos\r\n", "ID3" },

        { "Es un pequeño paraíso de diversidad, el cual salta a la vista desde alta mar cuando la frondosa" +
            " y exuberante selva húmeda tropical desciende desde las pequeñas cumbres nubladas hasta el azul" +
            " intenso de las aguas misteriosas del océano Pacífico. El Parque está conformado por dos islas:" +
            " Gorgona y Gorgonilla, que recibieron el nombre del conquistador Francisco Pizarro en 1527. " +
            "\r\nTomado de: https://www.parquesnacionales.gov.co/nuestros-parques/pnn-gorgona/\r\n", "ID4" },

        { "Lugar ubicado entre los municipios de Belalcázar e Inzá en el departamento del Cauca, " +
            "está localizada en la vertiente oriental de la Cordillera Central, y pertenece a la hoya " +
            "hidrográfica del río Magdalena. Se trata de un área con topografía quebrada, con cimas escarpadas " +
            "y profundos cañones que hacen difícil su acceso." +
            "Tomado de: https://www.parquesnacionales.gov.co/nuestros-parques/pnn-gorgona/", "ID5" },
    };

    ////MISAK
    //public Dictionary<string, string> palabrasIdentificadoresMisak = new Dictionary<string, string> {
    //    { "Marimba", "ID1" },
    //    { "Güiro", "ID2" },
    //    { "Tambora", "ID3" },
    //    { "Violines", "ID4" },
    //    { "Guitarra", "ID5" },
    //    { "Flauta", "ID6" },
    //    { "Saxofón", "ID7" },
    //    { "Maracas", "ID8" }
    //};

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


    //public KeyValuePair<string, string> GetRandomWordIdentifierMisak()
    //{
    //    if (palabrasIdentificadoresMisak.Count < 1)
    //    {
    //        mensajeJuegoGanado.SetActive(true);
    //    }
    //    int randomIndex = UnityEngine.Random.Range(0, palabrasIdentificadoresMisak.Count);
    //    var palabraIdentificador = palabrasIdentificadoresMisak.ElementAt(randomIndex);
    //    return palabraIdentificador;
    //}


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
        //Debug.Log("La clave encontrada para ese valor es: " + key);

        palabrasIdentificadores.Remove(key);
        Debug.Log("Se elimino la clave: "+ key);

        //Elimina también en los OTROS IDIOMAS de una vez XD
        //eliminarClaveValorMisak(valor);
        //eliminarClaveValorNasa(valor);
        //eliminarClaveValorQuechua(valor);
    }

    //public void eliminarClaveValorMisak(string valor)
    //{
    //    var key = palabrasIdentificadoresMisak.FirstOrDefault(x => x.Value == valor).Key;
    //    palabrasIdentificadoresMisak.Remove(key);
    //}

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

