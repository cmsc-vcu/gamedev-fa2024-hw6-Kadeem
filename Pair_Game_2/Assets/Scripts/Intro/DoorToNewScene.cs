using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNewScene : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private string sceneName;
    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
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

    void Update()
    {
        if(playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(waitThenLeave());
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private IEnumerator waitThenLeave()
    {
        //waiting like this prevents accidentally triggering something in the new scene
        yield return new WaitForSeconds(0.1f);
        //switching scene code here
        SceneManager.LoadScene(sceneName);
    }
}
