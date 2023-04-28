using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

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
    }


    //Fuction for if we desire to resume the game
    //Remove pause menu and resume time
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Function for if we desire to pause the game
    //Bring up pause menu and freeze time
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Restarts the game level
    //Need to unpause the game after restarting the scene, else the game won't load properly
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pulls up the options menu
    public void OptionsMenu(){

    }

    //Exits the game
    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
