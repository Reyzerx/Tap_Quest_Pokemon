using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFrameForDefense : MonoBehaviour
{

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitAnimation()
    {
        Debug.Log("on est dans la keyframe >" + this.gameObject.name);
        player.FinAnimationDefense(this.gameObject);
    }
}
