using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //referencias
        TMP_Text verde = GameObject.Find("verde").GetComponent<TMP_Text>();
        TMP_Text rojo = GameObject.Find("rojo").GetComponent<TMP_Text>();
        TMP_Text amarillo = GameObject.Find("amarillo").GetComponent<TMP_Text>();
        TMP_Text azul = GameObject.Find("azul").GetComponent<TMP_Text>();
        TMP_Text cafe = GameObject.Find("cafe").GetComponent<TMP_Text>();
        TMP_Text gris = GameObject.Find("gris").GetComponent<TMP_Text>();
        TMP_Text cyan = GameObject.Find("cyan").GetComponent<TMP_Text>();

        List<UserModel> userModel = UserApiLocal.FindAll();


        int totalCafe=0, totalAmarillo=0, totalVerde=0, totalCyan=0, totalGris=0;
        userModel.ForEach(user =>
        {
            List<GameStateModel> gameState = GameStateApiLocal.FindByIdUser(user.id);
            if (gameState != null)
            {
                int totalAttemps=0, totalTools=0, totalCoins=0, totalGameTime=0;
                List<int> nivelesCompletados = new List<int>();

                //recorrer la informacion
                gameState.ForEach(state => {
                    totalAttemps = totalAttemps + Int32.Parse(state.attempts);
                    nivelesCompletados.Add(state.id_level_description);
                    totalTools += state.tools;
                    totalCoins += Int32.Parse(state.coins);
                    totalGameTime += Int32.Parse(state.game_time);
                });
                //solo contal los elementos NO repetidos de la lista
                var nivelesSinRepetir = nivelesCompletados.Distinct();

                //sumar con los anteriores
                totalCafe += nivelesSinRepetir.Count();
                totalAmarillo += totalAttemps;
                totalVerde += totalTools;
                totalCyan += totalCoins;
                totalGris += totalGameTime;
            }
        });

        //establecer los datos
        verde.SetText(totalVerde + "");
        cafe.SetText(totalCafe + "");
        amarillo.SetText(totalAmarillo + "");
        gris.SetText(totalGris + "");
        cyan.SetText(totalCyan + "");

    }

    // Update is called once per frame
    public void Back()
    {
        SceneManager.LoadScene("2 MenuPrincipal");
    }
}
