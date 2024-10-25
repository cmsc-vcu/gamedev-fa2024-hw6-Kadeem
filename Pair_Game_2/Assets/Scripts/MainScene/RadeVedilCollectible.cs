using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadeVedilCollectible : MonoBehaviour
{
    [SerializeField] RadeVedilDialogue rvd;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            rvd.phase++;
        }
    }
}
