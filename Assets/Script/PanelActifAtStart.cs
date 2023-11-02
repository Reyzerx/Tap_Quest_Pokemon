using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActifAtStart : MonoBehaviour
{
    public GameObject[] objetADesactiverAuStart;
    public GameObject[] objetAActiverAuStart;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject currentObjetADesactiver in objetADesactiverAuStart){
            currentObjetADesactiver.SetActive(false);
        }

        foreach (GameObject currentObjetAActiver in objetAActiverAuStart)
        {
            currentObjetAActiver.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
