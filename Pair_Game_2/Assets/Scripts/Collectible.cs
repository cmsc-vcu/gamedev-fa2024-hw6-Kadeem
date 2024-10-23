using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        visual.SetActive(true);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            visual.SetActive(false);     
            CollectibleManager.GetInstance().Collect();
        }
    }
}
