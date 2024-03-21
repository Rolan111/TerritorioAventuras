using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CantidadBasurasRestantes : MonoBehaviour
{

   
    public TMP_Text miTextoTMP; // La referencia al componente TextMeshPro

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (miTextoTMP.isActiveAndEnabled)
        {
            // Encuentra el GameObject que tiene Script1 adjunto, el script que tiene el contador
            GameObject objetoConScript1 = GameObject.Find("Bote");

            if (objetoConScript1 != null)
            {
                // Obtén la referencia al script Script1 desde el GameObject
                DetectorColisionesBote script1 = objetoConScript1.GetComponent<DetectorColisionesBote>();

                if (script1 != null)
                {
                    // Ahora puedes acceder a la variable pública miVariablePublica
                    int valorDeLaVariablePublica = script1.contadorTotalDeResiduos;
                    Debug.Log("Valor de miVariablePublica en Script1 222: " + valorDeLaVariablePublica);
                    int basurasRestantes = 7 - valorDeLaVariablePublica;
                    miTextoTMP.text = basurasRestantes.ToString();
                }
                else
                {
                    Debug.LogError("Script1 no encontrado en el objeto " + objetoConScript1.name);
                }
            }
            else
            {
                Debug.LogError("Objeto con nombre NombreDelObjetoConScript1 no encontrado.");
            }
        }
        
    }



}
