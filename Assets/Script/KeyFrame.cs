using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFrame : MonoBehaviour
{

    public Player player;
    public AudioSource audioSourceAttaquePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAttaqueMusic()
    {
        audioSourceAttaquePlayer.Play();
    }

    public void OnExitAnimation()
    {
        player.FinAnimationDefense(this.gameObject);
    }
}
