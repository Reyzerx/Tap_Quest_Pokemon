using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public void DebutPlayerAttaque(GameObject playerObject, Button boutonAttaque)
    {
        //Lancer animation
        playerObject.GetComponent<Animator>().SetTrigger("isAttacking");
        //Désactiver le bouton
        boutonAttaque.enabled = false;
        //ajouter un event a la fin de l'animation pour infliger les dégat
        //Réactiver le bouton
    }
    public void FinPlayerAttaque(GameObject ennemiObject, EnnemiPokemonData currentEnnemi, Button boutonAttaque)
    {
        ennemiObject.transform.GetChild(1).GetComponent<Slider>().value = currentEnnemi.hp;
        boutonAttaque.enabled = true;
    }
}
