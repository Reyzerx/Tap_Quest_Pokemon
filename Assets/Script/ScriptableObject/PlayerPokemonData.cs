using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPokemonData", menuName = "Mes ScriptableObject/PlayerPokemonData")]
public class PlayerPokemonData : ScriptableObject
{
    public string idName;

    public Sprite sprite;
    public int hp;
    public int hpMax;

    public int degat;
    public int multiplicateurOrParPokemon;
    public int multiplicateurXpParPokemon;


    public int coutAugmentationHp;
    public int coutAugmentationDegat;
    public int coutAugmentationMultiplicateurOrParPokemon;
    public int coutAugmentationMultiplicateurXpParPokemon;
}
