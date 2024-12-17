using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzaSkripta : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public GameObject upitnik;

    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused == true){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
        
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        upitnik.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        upitnik.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    public void GoMainMenu(){
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(0);
    }
}
