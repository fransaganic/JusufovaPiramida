using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool SampleSceneStartGame = true;
    public static bool SampleSceneFinishedGame = false;
    public static string TimerText;
    public static float currentTime;
    public void LoadGame()
    {
        /*
        PlayerPrefs.SetInt("trueEnding", 0);
        PlayerPrefs.SetInt("susEnding", 0);
        PlayerPrefs.SetInt("bonkEnding", 0);
        PlayerPrefs.SetInt("squashEnding", 0);
        PlayerPrefs.SetInt("goodEnding", 0);
        PlayerPrefs.SetString("goodTimer", "");
        PlayerPrefs.SetString("squashTimer", "");
        PlayerPrefs.SetString("bonkTimer", "");
        PlayerPrefs.SetString("trueTimer", "");
        PlayerPrefs.SetString("susTimer", "");
        */
        
        TimerText = "0";
        currentTime = 0f;
        SampleSceneStartGame = true;
        SampleSceneFinishedGame = false;
        InventoryManager.items.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void GoMainMenu(){
        SceneManager.LoadScene(0);
    }
}
