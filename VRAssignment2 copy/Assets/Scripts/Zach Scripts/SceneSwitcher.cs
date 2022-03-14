using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSwitcher : MonoBehaviour
{
    private int nextSceneToLoad;
    private int currentScene;

    public bool keyCollected = false;
    public GameObject message;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;


    private void Start()
    {
        // Activates starting message
        message.SetActive(true);

        // Starts the timer automatically
        timerIsRunning = true;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currentScene = nextSceneToLoad - 1;
        
    }

    void Update()
    {
        // If the timer is running
        if (timerIsRunning == true)
        {
            // And there is a time remaining
            if (timeRemaining > 0)
            {
                // Decrease time remaining
                timeRemaining -= Time.deltaTime;
                // Update the display time
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;
            }
        }
        // Otherwise
        else
        {

            // Log time out
            Debug.Log("Time has run out!");

            // Set time remaining to zero
            timeRemaining = 0;

            // Restart the game?
            QuitGame();
        }

    }
    
    public void DisplayTime(float timeToDisplay)
    {
        
        timeToDisplay += 1;
        // Sets minute measurements
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        // Sets second measurements
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // Sets timeText to display the current time left over in minutes and seconds
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateKey()
    {
        keyCollected = true;
    }

    public void ChangeScene()
    {
        if (keyCollected == true)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
