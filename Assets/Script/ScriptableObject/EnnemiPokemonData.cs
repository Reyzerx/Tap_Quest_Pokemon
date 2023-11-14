using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnnemiPokemonData", menuName = "Mes ScriptableObject/EnnemiPokemonData")]
public class EnnemiPokemonData : ScriptableObject
{
    public string idName;

    public Sprite sprite;
    public int hp;
    public int hpMax;

    public int degat;

    public int orGiven;
}
