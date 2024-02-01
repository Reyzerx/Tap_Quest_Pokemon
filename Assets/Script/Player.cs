using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerPokemonData currentPokemonData;
    public Button boutonAttaque;
    public Button boutonDefense;

    //public Slider sliderHp

    public GameObject playerObject;


    private void Start()
    {
        
    }

    public int Xp { get => currentPokemonData.xp; set => currentPokemonData.xp = value; }
    public int PokeDollars { get => currentPokemonData.pokeDollars; set => currentPokemonData.pokeDollars = value; }
    public Sprite Sprite { get => currentPokemonData.sprite; set => currentPokemonData.sprite = value; }
    public int Hp { get => currentPokemonData.hp; set => currentPokemonData.hp = value; }
    public int HpMax { get => currentPokemonData.hpMax; set => currentPokemonData.hpMax = value; }
    public int Degat { get => currentPokemonData.degat; set => currentPokemonData.degat = value; }
    public int MultiplicateurOrParPokemon { get => currentPokemonData.multiplicateurOrParPokemon; set => currentPokemonData.multiplicateurOrParPokemon = value; }
    public int MultiplicateurXpParPokemon { get => currentPokemonData.multiplicateurXpParPokemon; set => currentPokemonData.multiplicateurXpParPokemon = value; }
    public int CoutAugmentationHp { get => currentPokemonData.coutAugmentationHp; set => currentPokemonData.coutAugmentationHp = value; }
    public int CoutAugmentationDegat { get => currentPokemonData.coutAugmentationDegat; set => currentPokemonData.coutAugmentationDegat = value; }
    public int CoutAugmentationMultiplicateurOrParPokemon { get => currentPokemonData.coutAugmentationMultiplicateurOrParPokemon; set => currentPokemonData.coutAugmentationMultiplicateurOrParPokemon = value; }
    public int CoutAugmentationMultiplicateurXpParPokemon { get => currentPokemonData.coutAugmentationMultiplicateurXpParPokemon; set => currentPokemonData.coutAugmentationMultiplicateurXpParPokemon = value; }


    public void DeclenchementAnimationAttaque()
    {
        playerObject.GetComponent<Animator>().SetBool("isAttacking", true);
        boutonAttaque.interactable = false;
        boutonDefense.interactable = false;
    }

    public void FinAnimationAttaque()
    {
        boutonAttaque.interactable = true;
        boutonDefense.interactable = true;
    }

    public void FinAnimationAttaqueIfReturnToMenu()
    {
        boutonAttaque.interactable = true;
        boutonDefense.interactable = true;
        playerObject.GetComponent<Animator>().SetBool("isAttacking", false);

        playerObject.transform.localPosition = new Vector2(190, 0);
    }

    public void DeclenchementAnimationDefense(GameObject bouclierDefenseObject)
    {
        bouclierDefenseObject.GetComponent<Animator>().SetBool("isDefending", true);
        boutonAttaque.interactable = false;
        boutonDefense.interactable = false;

    }

    public void FinAnimationDefense(GameObject bouclierDefenseObject)
    {
        bouclierDefenseObject.GetComponent<Animator>().SetBool("isDefending", false);
        
        boutonAttaque.interactable = true;
        boutonDefense.interactable = true;

        Debug.Log("On est dans la fin anim defense >" + bouclierDefenseObject.name);

    }

}
