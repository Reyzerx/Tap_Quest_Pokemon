using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickButton : MonoBehaviour
{

    public Image spriteForInfoPokemon;

    public GameObject selectedPokemonHpObjet;
    public GameObject selectedPokemonDamageObjet;
    public GameObject selectedPokemonOrRecuObjet;
    public GameObject selectedPokemonXpRecuObjet;


    public PlayerPokemonData[] scriptableObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAllInfoForSelectedPokemon(string idName)
    {
        PlayerPokemonData tmpPlayerPokemonData = null;

        foreach(PlayerPokemonData currentPokemonData in scriptableObject)
        {
            if(currentPokemonData.idName == idName)
            {
                tmpPlayerPokemonData = currentPokemonData;
            }
        }

        if(tmpPlayerPokemonData != null)
        {
            spriteForInfoPokemon.sprite = tmpPlayerPokemonData.sprite;

            //Set des textes pour le pokemon selectionné
            selectedPokemonHpObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hp : " + tmpPlayerPokemonData.hp.ToString() + "\n" + "Cost : " + tmpPlayerPokemonData.coutAugmentationHp.ToString();
            selectedPokemonDamageObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Damage : " + tmpPlayerPokemonData.damage.ToString() + "\n" + "Cost : " + tmpPlayerPokemonData.coutAugmentationDamage.ToString();
            selectedPokemonOrRecuObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Or recu : x" + tmpPlayerPokemonData.multiplicateurOrParPokemon.ToString() + "\n" + "Cost : " + tmpPlayerPokemonData.coutAugmentationMultiplicateurOrParPokemon.ToString();
            selectedPokemonXpRecuObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Xp recu : x" + tmpPlayerPokemonData.multiplicateurXpParPokemon.ToString() + "\n" + "Cost : " + tmpPlayerPokemonData.coutAugmentationMultiplicateurXpParPokemon.ToString();

        }

    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

}
