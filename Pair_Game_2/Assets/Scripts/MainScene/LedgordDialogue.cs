using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgordDialogue : MonoBehaviour
{   
    public GameObject chattable;
    private bool playerInRange;
    [SerializeField] private TextAsset beforeGiftJSON;
    [SerializeField] private TextAsset beforeGiftContJSON;
    [SerializeField] private TextAsset afterGiftJSON;
    [SerializeField] private TextAsset afterGiftContJSON;
    public int phase;
    
    private void Awake()
    {
        chattable.SetActive(false);
        playerInRange = false;
        phase = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            playerInRange=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            chattable.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(waitThenDialogue());
            }
        }
        else
        {
            chattable.SetActive(false);
        }
    }

    private IEnumerator waitThenDialogue()
    {
        //waiting like this prevents accidentally skipping the first line of dialogue
        yield return new WaitForSeconds(0.1f);
        switch(phase)
        {
            case 0:
                phase=1;
                DialogueManager.GetInstance().EnterDialogueMode(beforeGiftJSON);
                break;
            case 1:
                DialogueManager.GetInstance().EnterDialogueMode(beforeGiftContJSON);
                break;
            case 2:
                DialogueManager.GetInstance().EnterDialogueMode(afterGiftJSON);
                phase=3;
                break;
            case 3:
                DialogueManager.GetInstance().EnterDialogueMode(afterGiftContJSON);
                break;
            default:
                DialogueManager.GetInstance().EnterDialogueMode(afterGiftContJSON);
                break;
        }
        
    }
}
