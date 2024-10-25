using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LedgordGiftCollectible : MonoBehaviour
{
    [SerializeField] LedgordDialogue ld;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            ld.phase++;
        }
    }
}
