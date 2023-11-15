using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    //Pour infliger les dégats avec le bouton attaque
    public int currentEnnemiIndex = 0;
    public EnnemiPokemonData currentEnnemi;
    public GameObject ennemiObject;

    public PlayerPokemonData currentPlayerPokemon;

    public EnnemiPokemonData[] listEnnemiZone1;



    // Start is called before the first frame update
    void Start()
    {
        //Set des éléments graphique por le premier ennemi 
        refreshUIForEnnemi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetEnnemiStatsForRestartGame()
    {
        foreach(EnnemiPokemonData currentEnnemiPokemon in listEnnemiZone1)
        {
            currentEnnemiIndex = 0;
            currentEnnemi = listEnnemiZone1[currentEnnemiIndex];
            refreshUIForEnnemi();

            currentEnnemiPokemon.hp = currentEnnemiPokemon.hpMax;
        }
    }

    public void refreshUIForEnnemi()
    {
        //Set des éléments graphique por le premier ennemi 
        ennemiObject.transform.GetChild(0).GetComponent<Image>().sprite = currentEnnemi.sprite;

        ennemiObject.transform.GetChild(1).GetComponent<Slider>().maxValue = currentEnnemi.hpMax;
        ennemiObject.transform.GetChild(1).GetComponent<Slider>().value = currentEnnemi.hp;
    }

    public void nextEnnemi()
    {
        currentEnnemiIndex++;

        if(currentEnnemiIndex <= listEnnemiZone1.Length-1)
        {
            currentPlayerPokemon.xp += currentEnnemi.xpGiven;

            currentEnnemi = listEnnemiZone1[currentEnnemiIndex];
            refreshUIForEnnemi();
        }

        //************
        //EN ATTENDANT
        //************
        else
        {
            Debug.Log("on passe ici");
            resetEnnemiStatsForRestartGame();
            currentEnnemiIndex = 0;

            currentEnnemi = listEnnemiZone1[currentEnnemiIndex];
            refreshUIForEnnemi();
        }
    }
}
