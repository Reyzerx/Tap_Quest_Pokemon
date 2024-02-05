using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData2 : MonoBehaviour
{
    public PlayerPokemonData playerDataToSave;
    public EnnemiPokemonData[] enemyDataToSave;


    [Header("Objet a Load")]
    public Player playerDataToLoad;
    public Enemy enemyDataToLoad;
    public GameCore gameDataToLoad;

    public void SaveData()
    {
        playerDataToSave = playerDataToLoad.currentPokemonData;
        enemyDataToSave = gameDataToLoad.listEnnemiZone1;
    }

    public void LoadData()
    {

    }
}
