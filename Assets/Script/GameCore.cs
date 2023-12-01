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
    public GameObject playerObject;

    public EnnemiPokemonData[] listEnnemiZone1;


    //La stat actuelle qu'on veut augmenter
    public string selectedAmelioration = "";

    //Temporaire
    public int augmentation = 10;



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

    public void ResetPlayerStatsForRestartGame()
    {

        RefreshUIForPlayer();
        currentPlayerPokemon.hp = currentPlayerPokemon.hpMax;
    }
    public void RefreshUIForPlayer()
    {
        //Set des éléments graphique por le premier ennemi 
        playerObject.transform.GetChild(0).GetComponent<Image>().sprite = currentPlayerPokemon.sprite;

        playerObject.transform.GetChild(1).GetComponent<Slider>().maxValue = currentPlayerPokemon.hpMax;
        playerObject.transform.GetChild(1).GetComponent<Slider>().value = currentPlayerPokemon.hp;
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

    public void InfligerDegatAEnnemi()
    {
        //Application des dégats
        currentEnnemi.hp -= currentPlayerPokemon.degat;

        if (currentEnnemi.hp <= 0)
        {
            nextEnnemi();
        }
        else
        {
            ennemiObject.transform.GetChild(1).GetComponent<Slider>().value = currentEnnemi.hp;
        }
    }

    public void AddStatsWithAgmentation()
    {
        if(selectedAmelioration == "hp")
        {
            if(currentPlayerPokemon.xp >= currentPlayerPokemon.coutAugmentationHp)
            {
                currentPlayerPokemon.xp -= currentPlayerPokemon.coutAugmentationHp;

                currentPlayerPokemon.hp += augmentation;
                currentPlayerPokemon.hpMax += augmentation;
                currentPlayerPokemon.coutAugmentationHp += augmentation;
            }
        }
        if (selectedAmelioration == "degat")
        {
            if (currentPlayerPokemon.xp >= currentPlayerPokemon.coutAugmentationDegat)
            {
                currentPlayerPokemon.xp -= currentPlayerPokemon.coutAugmentationDegat;

                currentPlayerPokemon.degat += augmentation;
                currentPlayerPokemon.coutAugmentationDegat += augmentation;
            }
        }
        if (selectedAmelioration == "pokedollars")
        {
            if (currentPlayerPokemon.xp >= currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon)
            {
                currentPlayerPokemon.xp -= currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon;

                currentPlayerPokemon.multiplicateurOrParPokemon += augmentation;
                currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon += augmentation;
            }
        }
        if (selectedAmelioration == "xp")
        {
            if (currentPlayerPokemon.xp >= currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon)
            {
                currentPlayerPokemon.xp -= currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon;

                currentPlayerPokemon.multiplicateurXpParPokemon += augmentation;
                currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon += augmentation;
            }
        }
    }
}
