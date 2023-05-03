using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsWon = false;
    public static bool VolumeEnabled = true;
    public GameObject pauseMenuUI;
    public GameObject winMenuUI;
    public GameObject uiCamera;
    public GameObject optionsMenuUI;
    public GameObject cameraAudio;
    public GameObject canvasAudio;
    public GameObject skateAudio;
    public Vector3 skateVelocity;

    private void Start()
    {
        //Disabling the music so that it doesn't play on start up if player disabled volume before scene restart
        if (!VolumeEnabled){
            cameraAudio.GetComponent<AudioSource>().enabled = false;
        }

        GameIsWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Will pause or resume the game is Escape button is pressed
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }

        //Will pause the game and bring up the win menu if win score is met
        if (!GameIsWon){
            if (uiCamera.GetComponent<ScoreTracker>().scoreNum >= 100){
                Win();
            }
        }
    }

    //Fuction for if we desire to resume the game
    //Remove pause menu and resume time
    public void Resume()
    {
        winMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        //Resume playing skateboard audio by enabling it and resetting velocity
        skateAudio.GetComponent<Rigidbody>().velocity = skateVelocity;

        //Change background music
        if (VolumeEnabled){
            cameraAudio.GetComponent<AudioSource>().enabled = true;
            canvasAudio.GetComponent<AudioSource>().enabled = false;
        }
    }

    //Function for if we desire to pause the game
    //Bring up pause menu and freeze time
    void Pause()
    {
        winMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        //Pausing Skateboard audio
        skateAudio.GetComponent<AudioSource>().enabled = false;
        skateVelocity = skateAudio.GetComponent<Rigidbody>().velocity;
        skateAudio.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        //Change background music
        if (VolumeEnabled){
            cameraAudio.GetComponent<AudioSource>().enabled = false;
            canvasAudio.GetComponent<AudioSource>().enabled = true;
        }
    }

    //The win menu acts similarly to the Resume function but calls a different Menu
    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameIsWon = true;

        //Pausing Skateboard audio
        skateAudio.GetComponent<AudioSource>().enabled = false;
        skateVelocity = skateAudio.GetComponent<Rigidbody>().velocity;
        skateAudio.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //Change background music
        if (VolumeEnabled)
        {
            cameraAudio.GetComponent<AudioSource>().enabled = false;
            canvasAudio.GetComponent<AudioSource>().enabled = true;
        }
    }


    //Restarts the game level
    //Need to unpause the game after restarting the scene, else the game won't load properly
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pulls up the options menu
    public void OptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    //Exits the game
    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //The code below is related to the Options Menu
    public void Back(){
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    //Function will enable or disable the sounds playing in the game
    public void VolumeToggle(){
        if (VolumeEnabled){
            //Disable all sounds
            VolumeEnabled = false;
            canvasAudio.GetComponent<AudioSource>().enabled = false;
        } else {
            //Renable sounds
            VolumeEnabled = true;
            canvasAudio.GetComponent<AudioSource>().enabled = true;
        }
    }
}
