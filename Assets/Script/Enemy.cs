using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public EnnemiPokemonData currentEnemyData;
    public Slider sliderHp;
    public GameObject enemyObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite Sprite { get => currentEnemyData.sprite; set => currentEnemyData.sprite = value; }
    public int Hp { get => currentEnemyData.hp; set => currentEnemyData.hp = value; }
    public int HpMax { get => currentEnemyData.hpMax; set => currentEnemyData.hpMax = value; }
    public int Degat { get => currentEnemyData.degat; set => currentEnemyData.degat = value; }
    public int XpGiven { get => currentEnemyData.xpGiven; set => currentEnemyData.xpGiven = value; }
}
