using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickButton : MonoBehaviour
{

    public Image spriteForInfoPokemon;

    public TextMeshProUGUI playerStatsTexte;

    //Affichage des differente stats du pokémon choisi
    public GameObject selectedPokemonHpObjet;
    public GameObject selectedPokemonDamageObjet;
    public GameObject selectedPokemonOrRecuObjet;
    public GameObject selectedPokemonXpRecuObjet;

    //objet dans lequel il y a le text et les boutons d'augmentation de la selected stat
    public GameObject panelAugmentationStats;

    //Script pour avoir les infos du GameCore
    public GameCore scriptGameCore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void infligerDegat()
    {
        //Application des dégats
        scriptGameCore.currentEnnemi.hp -= scriptGameCore.currentPlayerPokemon.degat;
            
        if(scriptGameCore.currentEnnemi.hp <= 0)
        {
            scriptGameCore.nextEnnemi();
        }
        else
        {
            scriptGameCore.ennemiObject.transform.GetChild(1).GetComponent<Slider>().value = scriptGameCore.currentEnnemi.hp;
        }
    }

    public void setAllInfoForSelectedPokemon()
    {
        PlayerPokemonData tmpPlayerPokemonData = scriptGameCore.currentPlayerPokemon;

        //foreach (PlayerPokemonData currentPokemonData in scriptableObject)
        //{
        //    if(currentPokemonData.idName == idName)
        //    {
        //        tmpPlayerPokemonData = currentPokemonData;
        //    }
        //}

        if(tmpPlayerPokemonData != null)
        {
            spriteForInfoPokemon.sprite = tmpPlayerPokemonData.sprite;

            playerStatsTexte.text = "Xp : " + tmpPlayerPokemonData.xp.ToString();

            //Set des textes pour le pokemon selectionné
            selectedPokemonHpObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hp : " + tmpPlayerPokemonData.hp.ToString();
            selectedPokemonDamageObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Dégats : " + tmpPlayerPokemonData.degat.ToString();
            selectedPokemonOrRecuObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Pokédollars recu : x" + tmpPlayerPokemonData.multiplicateurOrParPokemon.ToString();
            selectedPokemonXpRecuObjet.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Xp recu : x" + tmpPlayerPokemonData.multiplicateurXpParPokemon.ToString();

        }

    }

    public void SetInfoForSelectedAmelioration(string name)
    {
        string tmpStringForTexte = "";

        if (name == "hp")
        {
            tmpStringForTexte = "HP : " + scriptGameCore.currentPlayerPokemon.hp.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.hp + 10).ToString();
            tmpStringForTexte += "\n";
            tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationHp.ToString() + " pokédollars";

            panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
        }
        else if (name == "degat")
        {
            tmpStringForTexte = "DEGATS : " + scriptGameCore.currentPlayerPokemon.degat.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.degat + 10).ToString();
            tmpStringForTexte += "\n";
            tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationDegat.ToString() + " pokédollars";

            panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
        }
        else if (name == "pokedollars")
        {
            tmpStringForTexte = "POKEDOLLARS RECU : " + scriptGameCore.currentPlayerPokemon.multiplicateurOrParPokemon.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.pokeDollars + 10).ToString();
            tmpStringForTexte += "\n";
            tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon.ToString() + " pokédollars";

            panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
        }
        else if (name == "xp")
        {
            tmpStringForTexte = "XP RECU : " + scriptGameCore.currentPlayerPokemon.multiplicateurXpParPokemon.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.xp + 10).ToString();
            tmpStringForTexte += "\n";
            tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon.ToString() + " pokédollars";

            panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
        }
    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

}
