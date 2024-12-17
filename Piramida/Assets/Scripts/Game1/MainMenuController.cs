using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void PlayGame() {
        SceneManager.LoadScene("Game1");
    }

    public void ExitGame() {
        Debug.Log("SampleSceneStartGame bi tebao biti sada false");
        MainMenu.SampleSceneStartGame = false;
        SceneManager.LoadScene("SampleScene");
        
    }

    public void ExitGameSuccessfuly() {
        Debug.Log("SampleSceneStartGame bi tebao biti sada false");
        MainMenu.SampleSceneStartGame = false;
        MainMenu.SampleSceneFinishedGame = true;
        SceneManager.LoadScene("SampleScene");
    }

    void Waiting(){

    }
}
