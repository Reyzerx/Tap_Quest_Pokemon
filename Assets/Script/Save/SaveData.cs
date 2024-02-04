using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    public static Data data = new Data();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setAllObjectToSave()
    {
        //playerObject = GameObject.Find("Canvas/Player");
        //enemyObject = GameObject.Find("Canvas/Enemy");

        ////Player
        //data.starter = PlayerCore.starter;
        //data.selectedPokemon = playerObject.GetComponent<PlayerCore>().currentPlayerPokemon;
        //data.selectedPokemonStats = playerObject.GetComponent<PlayerCore>().currentPlayerPokemonStats;
        //data.gold = playerObject.GetComponent<PlayerCore>().coin;
        //data.equipePokemonPlayer = playerObject.GetComponent<PlayerCore>().playerPokemon;
        ////data.pokedex = playerScript.;
        ////data.multiExp = playerScript.;
        //data.storagePokemon = playerObject.GetComponent<PlayerCore>().storagePokemon;

        ////Enemy
        //data.badgeAvailable = enemyObject.GetComponent<EnemyCore>().badgeAvailable;
        //data.badgePlayerObtain = enemyObject.GetComponent<EnemyCore>().badgePlayerObtain;
        //data.routesActivate = enemyObject.GetComponent<EnemyCore>().routeActivate;
    }

    public void setAllObjectToLoad()
    {
        //playerObject = GameObject.Find("Canvas/Player");
        //enemyObject = GameObject.Find("Canvas/Enemy");

        ////Player
        ////Deja set avant le chargement de la scene
        ////PlayerCore.starter = data.starter;
        //playerObject.GetComponent<PlayerCore>().currentPlayerPokemon = data.selectedPokemon;
        //playerObject.GetComponent<PlayerCore>().currentPlayerPokemonStats = data.selectedPokemonStats;
        //playerObject.GetComponent<PlayerCore>().coin = data.gold;
        //playerObject.GetComponent<PlayerCore>().playerPokemon = data.equipePokemonPlayer;
        ////data.pokedex = playerScript.;
        ////data.multiExp = playerScript.;
        //playerObject.GetComponent<PlayerCore>().storagePokemon = data.storagePokemon;

        ////Enemy
        //enemyObject.GetComponent<EnemyCore>().badgeAvailable = data.badgeAvailable;
        //enemyObject.GetComponent<EnemyCore>().badgePlayerObtain = data.badgePlayerObtain;
        //enemyObject.GetComponent<EnemyCore>().routeActivate = data.routesActivate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
            Debug.Log("Save");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
            Debug.Log("Load");
        }
    }

    public void SaveToJson()
    {
        string saveData = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/SaveData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, saveData);
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";
        string saveData = System.IO.File.ReadAllText(filePath);

        data = JsonUtility.FromJson<Data>(saveData);
    }
}

[System.Serializable]
public class Data
{
    //Player Save
    [SerializeField]
    public Player player;

}