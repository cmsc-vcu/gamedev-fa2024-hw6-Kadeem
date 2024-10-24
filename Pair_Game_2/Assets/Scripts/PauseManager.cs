using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool isPaused;
    private static PauseManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("wtf there's another dialogue manager");
        }
        instance = this;
    }

    void Start()
    {
        Unpause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }

    public void Unpause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    //put EVERYTHING which needs to be restarted here
    public void Restart()
    {
        Debug.Log("pretend i restarted");
    }

    public static PauseManager GetInstance()
    {
        return instance;
    }
}
