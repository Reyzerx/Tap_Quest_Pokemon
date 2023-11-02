using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickButton : MonoBehaviour
{

    public Image spriteForInfoPokemon;
    public TextMeshProUGUI texteForInfoPokemon;

    //var objet statsForSalameche
    public Sprite statsForSalameche_sprite;
    public int statsForSalameche_hp = 10;
    public int statsForSalameche_degat = 5;
    public int statsForSalameche_orParPoke = 10;
    public int statsForSalameche_xpParPoke = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAllInfoForSelectedPokemon()
    {
        spriteForInfoPokemon.sprite = statsForSalameche_sprite;
        texteForInfoPokemon.text = "Hp : " + statsForSalameche_hp + "\n" + "D�gat : " + statsForSalameche_degat + "\n" + "Or par pok�mon : " + statsForSalameche_orParPoke + "\n" + "Xp par pok�mon : " + statsForSalameche_xpParPoke;
    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

}
