using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPokemonData", menuName = "Mes ScriptableObject/PlayerPokemonData")]
public class PlayerPokemonData : ScriptableObject
{
    public string idName;

    public Sprite sprite;
    public int hp;

    public int damage;
    public int multiplicateurOrParPokemon;
    public int multiplicateurXpParPokemon;


    public int coutAugmentationHp;
    public int coutAugmentationDamage;
    public int coutAugmentationMultiplicateurOrParPokemon;
    public int coutAugmentationMultiplicateurXpParPokemon;
}
