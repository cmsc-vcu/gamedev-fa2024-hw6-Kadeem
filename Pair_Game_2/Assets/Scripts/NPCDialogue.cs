using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{   
    public GameObject chattable;
    private bool playerInRange;
    [SerializeField] private TextAsset inkJSON;
    
    private void Awake()
    {
        chattable.SetActive(false);
        playerInRange = false;
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
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
