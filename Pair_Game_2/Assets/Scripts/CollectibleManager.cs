using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    private static CollectibleManager instance;
    [SerializeField] private TextMeshProUGUI collectibleText;
    private static int collectibleCount;
    [SerializeField] private int total;
    [SerializeField] private GameObject winScreen;
    

    public static CollectibleManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("wtf there's another collectible manager");
        }
        instance = this;
    }

    private void Start()
    {
        collectibleCount = 0;
        collectibleText.text = collectibleCount.ToString() + "/" + total.ToString();
        winScreen.SetActive(false);
    }

    public void Collect()
    {
        collectibleCount++;
        collectibleText.text = collectibleCount.ToString() + "/" + total.ToString();
    }

    
    void Update()
    {
        if(collectibleCount== total)
        {
            //trigger win effects
            winScreen.SetActive(true);
            print("YIPEEEEEEEEEE");
            collectibleCount++;
        }
    }


}
