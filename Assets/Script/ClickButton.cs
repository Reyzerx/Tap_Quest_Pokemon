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
        scriptGameCore.InfligerDegatAEnnemi();
    }

    public void setAllInfoForSelectedPokemon()
    {
        PlayerPokemonData tmpPlayerPokemonData = scriptGameCore.currentPlayerPokemon;

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

        scriptGameCore.selectedStatsToUp = name;

        if (name == "hp")
        {
            if(scriptGameCore.currentPlayerPokemon.xp < scriptGameCore.currentPlayerPokemon.coutAugmentationHp)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "HP : " + scriptGameCore.currentPlayerPokemon.hp.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.hp + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationHp.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

            
        }
        else if (name == "degat")
        {
            if (scriptGameCore.currentPlayerPokemon.xp < scriptGameCore.currentPlayerPokemon.coutAugmentationDegat)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "DEGATS : " + scriptGameCore.currentPlayerPokemon.degat.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.degat + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationDegat.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }
        else if (name == "pokedollars")
        {
            if (scriptGameCore.currentPlayerPokemon.xp < scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "POKEDOLLARS RECU : " + scriptGameCore.currentPlayerPokemon.multiplicateurOrParPokemon.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.multiplicateurOrParPokemon + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurOrParPokemon.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }
        else if (name == "xp")
        {
            if (scriptGameCore.currentPlayerPokemon.xp < scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }
            else
            {
                tmpStringForTexte = "XP RECU : " + scriptGameCore.currentPlayerPokemon.multiplicateurXpParPokemon.ToString() + " -> " + (scriptGameCore.currentPlayerPokemon.multiplicateurXpParPokemon + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + scriptGameCore.currentPlayerPokemon.coutAugmentationMultiplicateurXpParPokemon.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }

        //met a jour le texte avec les différentes stats
        panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

}
