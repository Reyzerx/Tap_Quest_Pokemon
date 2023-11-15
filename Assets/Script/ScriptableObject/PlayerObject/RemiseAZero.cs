using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemiseAZero : MonoBehaviour
{
    public PlayerPokemonData[] listPlayerPokemonData;
    public PlayerPokemonData valeurParDefaut;

    private void Start()
    {
        RemiseAZeroDesStats();
    }
    public void RemiseAZeroDesStats()
    {
        foreach(PlayerPokemonData currentPokemonData in listPlayerPokemonData)
        {
            currentPokemonData.xp = valeurParDefaut.xp;
            currentPokemonData.pokeDollars = valeurParDefaut.pokeDollars;

            currentPokemonData.hp = valeurParDefaut.hp;
            currentPokemonData.hpMax = valeurParDefaut.hpMax;

            currentPokemonData.degat = valeurParDefaut.degat;

            currentPokemonData.multiplicateurOrParPokemon = valeurParDefaut.multiplicateurOrParPokemon;
            currentPokemonData.multiplicateurXpParPokemon = valeurParDefaut.multiplicateurXpParPokemon;

            currentPokemonData.coutAugmentationHp = valeurParDefaut.coutAugmentationHp;
            currentPokemonData.coutAugmentationDegat = valeurParDefaut.coutAugmentationDegat;
            currentPokemonData.coutAugmentationMultiplicateurOrParPokemon = valeurParDefaut.coutAugmentationMultiplicateurOrParPokemon;
            currentPokemonData.coutAugmentationMultiplicateurXpParPokemon = valeurParDefaut.coutAugmentationMultiplicateurXpParPokemon;
        }
    }
}
