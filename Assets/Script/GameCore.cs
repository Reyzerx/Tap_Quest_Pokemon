using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    //Pour infliger les dégats avec le bouton attaque
    public int currentEnnemiIndex = 0;
    public Enemy enemy;
    public EnnemiPokemonData[] listEnnemiZone1;


    public Player player;


    //La stat actuelle qu'on veut augmenter
    public string selectedAmelioration = "";

    // le bouton d'attaque
    public Button boutonAttaque;

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
            enemy.currentEnemyData = listEnnemiZone1[currentEnnemiIndex];
            refreshUIForEnnemi();

            currentEnnemiPokemon.hp = currentEnnemiPokemon.hpMax;
        }
    }
    public void refreshUIForEnnemi()
    {
        //Set des éléments graphique por le premier ennemi 
        enemy.enemyObject.transform.GetChild(0).GetComponent<Image>().sprite = enemy.Sprite;

        enemy.enemyObject.transform.GetChild(1).GetComponent<Slider>().maxValue = enemy.HpMax;
        enemy.enemyObject.transform.GetChild(1).GetComponent<Slider>().value = enemy.Hp;
    }

    public void ResetPlayerStatsForRestartGame()
    {

        RefreshUIForPlayer();
        player.Hp = player.HpMax;
        player.FinAnimationAttaqueIfReturnToMenu();
    }
    public void RefreshUIForPlayer()
    {
        //Set des éléments graphique por le premier ennemi 
        player.playerObject.transform.GetChild(0).GetComponent<Image>().sprite = player.Sprite;

        player.playerObject.transform.GetChild(1).GetComponent<Slider>().maxValue = player.HpMax;
        player.playerObject.transform.GetChild(1).GetComponent<Slider>().value = player.Hp;
    }

    public void nextEnnemi()
    {
        currentEnnemiIndex++;

        if(currentEnnemiIndex <= listEnnemiZone1.Length-1)
        {
            player.Xp += enemy.XpGiven;

            enemy.currentEnemyData = listEnnemiZone1[currentEnnemiIndex];
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

            enemy.currentEnemyData = listEnnemiZone1[currentEnnemiIndex];
            refreshUIForEnnemi();
        }
    }

    public void ClicBoutonAttaque()
    {
        player.DeclenchementAnimationAttaque();
    }

    public void DegatForAnimPlayerAttaque()
    {
        //Application des dégats
        enemy.Hp -= player.Degat;
        //Mettre a jour la barre de vie de l'enemy
        enemy.sliderHp.value = enemy.currentEnemyData.hp;

        player.playerObject.GetComponent<Animator>().SetBool("isAttacking", false);

        if (enemy.Hp <= 0)
        {
            //Mettre une anim de mort du mob
            nextEnnemi();
        }
    }

    public void AddStatsWithAgmentation()
    {
        if(selectedAmelioration == "hp")
        {
            if(player.Xp >= player.CoutAugmentationHp)
            {
                player.Xp -= player.CoutAugmentationHp;

                player.Hp += augmentation;
                player.HpMax += augmentation;
                player.CoutAugmentationHp += augmentation;
            }
        }
        if (selectedAmelioration == "degat")
        {
            if (player.Xp >= player.CoutAugmentationDegat)
            {
                player.Xp -= player.CoutAugmentationDegat;

                player.Degat += augmentation;
                player.CoutAugmentationDegat += augmentation;
            }
        }
        if (selectedAmelioration == "pokedollars")
        {
            if (player.Xp >= player.CoutAugmentationMultiplicateurOrParPokemon)
            {
                player.Xp -= player.CoutAugmentationMultiplicateurOrParPokemon;

                player.MultiplicateurOrParPokemon += augmentation;
                player.CoutAugmentationMultiplicateurOrParPokemon += augmentation;
            }
        }
        if (selectedAmelioration == "xp")
        {
            if (player.Xp >= player.CoutAugmentationMultiplicateurXpParPokemon)
            {
                player.Xp -= player.CoutAugmentationMultiplicateurXpParPokemon;

                player.MultiplicateurXpParPokemon += augmentation;
                player.CoutAugmentationMultiplicateurXpParPokemon += augmentation;
            }
        }
    }
}
