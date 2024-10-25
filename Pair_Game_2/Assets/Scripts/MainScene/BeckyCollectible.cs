using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeckyCollectible : MonoBehaviour
{
    [SerializeField] BeckyDialogue bd;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            bd.phase++;
        }
    }
}
