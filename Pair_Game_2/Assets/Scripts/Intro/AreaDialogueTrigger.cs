using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    private bool dialoguePlayed;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePlayed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !dialoguePlayed)
        {
            StartCoroutine(waitThenDialogue());
            dialoguePlayed = true;
        }
    }

    private IEnumerator waitThenDialogue()
    {
        //waiting like this prevents accidentally skipping the first line of dialogue
        yield return new WaitForSeconds(0.1f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
