using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPrefabsMinijuegos : MonoBehaviour
{
    public GameObject prefabMinijuego1;
    public GameObject prefabMinijuego2;
    private GameObject instanciaPrefab;
    private int instanciaARecargar;
    //void Start()
    //{
    //    // Llamamos a nuestro método SpawnPrefab() para instanciarlo al inicio
    //    SpawnPrefab();
    //}

    //void Update()
    //{
    //    // Ejemplo de cómo llamar al método DestroyPrefab() y luego volver a instanciarlo en base a alguna condición
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DestroyPrefab();
    //        SpawnPrefab();
    //    }
    //}

    public void SpawnPrefab(int minijuegoAActivar)
    {
        instanciaARecargar = minijuegoAActivar;
        Vector3 newPosition = new Vector3(0f, 85f, 0f);//posición personalizada
        // Instanciamos el prefab en la posición inicial (0, 0, 0) y sin rotación
        if (minijuegoAActivar==1)
        {
            
            /*instanciaPrefab = Instantiate(prefabMinijuego1, Vector3.zero, Quaternion.identity);*/ //Dejar en la posición 0 por defecto
            instanciaPrefab = Instantiate(prefabMinijuego1, newPosition, Quaternion.identity);
        }
        else
        {
            instanciaPrefab = Instantiate(prefabMinijuego2, newPosition, Quaternion.identity);
        }

    }

    public void DestroyPrefab()
    {
        // Verificamos si ya hay una instancia del prefab y la destruimos
        if (instanciaPrefab != null)
        {
            Debug.Log("Si EXISTE UNA INSTANCIA");
            Destroy(instanciaPrefab);
        }
    }

    public void RecargarPrefab()
    {
        // Verificamos si ya hay una instancia del prefab y la destruimos
        if (instanciaPrefab != null) //Primero eliminamos
        {
            Destroy(instanciaPrefab);
        }
        StartCoroutine(SpawnRain());
    }

    IEnumerator SpawnRain() //luego se reinstancia
    {
        yield return new WaitForSeconds(0.5f);
        if (true)
        {
            
        }
        SpawnPrefab(instanciaARecargar);
    }


}
