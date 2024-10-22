using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public PlayerMovement pm; //player movement script

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            pm.Death(); //filler code. this should trigger Death 
        }
    }
}
