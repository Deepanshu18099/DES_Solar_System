using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    bool isPaused;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        GameObject audioObj = GameObject.FindWithTag("AudioObj");
        audioSource = audioObj.GetComponent<AudioSource>();

        // fetch audio source added on object tagged AudioObj

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }

        

        if(Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }


       //to toggle full screen 
        if(Input.GetKeyDown(KeyCode.F))
        {
                Screen.fullScreen = !Screen.fullScreen;
        }
        
    }
     void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Debug.Log("Pausing the game");
            Time.timeScale = 0f;
            if (audioSource != null)
            {
                audioSource.Pause();
            }
        }
        else
        {
            Debug.Log("Resuming the game");
            Time.timeScale = 1f;
            if (audioSource != null)
            {
                audioSource.UnPause();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
