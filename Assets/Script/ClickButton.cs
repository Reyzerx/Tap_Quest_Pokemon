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

    //Objet Player
    public Player player;

    public GameObject bouclierDefenseObject;

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
        scriptGameCore.ClicBoutonAttaque();
    }

    public void setAllInfoForSelectedPokemon()
    {
        PlayerPokemonData tmpPlayerPokemonData = player.currentPokemonData;

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

    public void SetSelectedAmelioration(string name)
    {
        scriptGameCore.selectedAmelioration = name;
    }

    public void SetInfoForSelectedAmelioration()
    {
        string tmpStringForTexte = "";

        if (scriptGameCore.selectedAmelioration == "hp")
        {
            if(player.Xp < player.CoutAugmentationHp)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "HP : " + player.Hp.ToString() + " -> " + (player.Hp + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + player.CoutAugmentationHp.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

            
        }
        else if (scriptGameCore.selectedAmelioration == "degat")
        {
            if (player.Xp < player.CoutAugmentationDegat)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "DEGATS : " + player.Degat.ToString() + " -> " + (player.Degat + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + player.CoutAugmentationDegat.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }
        else if (scriptGameCore.selectedAmelioration == "pokedollars")
        {
            if (player.Xp < player.CoutAugmentationMultiplicateurOrParPokemon)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }

            else
            {
                tmpStringForTexte = "POKEDOLLARS RECU : " + player.MultiplicateurOrParPokemon.ToString() + " -> " + (player.MultiplicateurOrParPokemon + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + player.CoutAugmentationMultiplicateurOrParPokemon.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }
        else if (scriptGameCore.selectedAmelioration == "xp")
        {
            if (player.Xp < player.CoutAugmentationMultiplicateurXpParPokemon)
            {
                tmpStringForTexte = "Xp insufisant pour augmentation";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }
            else
            {
                tmpStringForTexte = "XP RECU : " + player.MultiplicateurXpParPokemon.ToString() + " -> " + (player.MultiplicateurXpParPokemon + scriptGameCore.augmentation).ToString();
                tmpStringForTexte += "\n";
                tmpStringForTexte += "COUT : " + player.CoutAugmentationMultiplicateurXpParPokemon.ToString() + " xp";

                panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
                panelAugmentationStats.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

        }

        //met a jour le texte avec les différentes stats
        panelAugmentationStats.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpStringForTexte;
    }

    public void ClicDefenseBoutonPlayer()
    {
        player.DeclenchementAnimationDefense(bouclierDefenseObject);
    }

    public void QuitterApplication()
    {
        Application.Quit();
    }

}
