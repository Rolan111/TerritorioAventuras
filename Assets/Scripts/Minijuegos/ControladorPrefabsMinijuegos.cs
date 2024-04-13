using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPrefabsMinijuegos : MonoBehaviour
{
    public GameObject miPrefab;
    private GameObject instanciaPrefab;

    //void Start()
    //{
    //    // Llamamos a nuestro m�todo SpawnPrefab() para instanciarlo al inicio
    //    SpawnPrefab();
    //}

    //void Update()
    //{
    //    // Ejemplo de c�mo llamar al m�todo DestroyPrefab() y luego volver a instanciarlo en base a alguna condici�n
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DestroyPrefab();
    //        SpawnPrefab();
    //    }
    //}

    public void SpawnPrefab()
    {
        // Instanciamos el prefab en la posici�n inicial (0, 0, 0) y sin rotaci�n
        instanciaPrefab = Instantiate(miPrefab, Vector3.zero, Quaternion.identity);
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
        yield return new WaitForSeconds(1f);
        SpawnPrefab();
    }


}
