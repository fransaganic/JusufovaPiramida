using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadActions:MonoBehaviour {


    //[SerializeField] 
    //private Transform player; //drag player reference onto here    provjera bez ovoga za loadanje pozicije playera
    [SerializeField]
    private Vector3 StartPlayerPosition; //here you store the position you want to teleport your player to

    [SerializeField]
    private Vector3 PlayerPositionAfterGame1;

    [SerializeField]
    private Animator animMainDoors;

    [SerializeField]
    private Animator animVrataDvorane;

    [SerializeField]
    private Animator animMalaVrataLijevo;

    public AudioSource source;
    public AudioClip clip;

    public GameObject player;   //provjera za poziciju

    private void OnEnable() {
        //animMainDoors.SetBool("OpenedMainDoors", false);
        //animVrataDvorane.SetBool("OpenedVrataDvorane", false);
        //animMalaVrataLijevo.SetBool("Opened", false); 
        Debug.Log("Sad sam ga pokrenuo");
        Time.timeScale = 1;
        SceneManager.sceneLoaded += SceneLoaded; //You add your method to the delegate
    }

    private void OnDisable() {
        Debug.Log("Sad sam ga zaustavio");
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    //After adding this method to the delegate, this method will be called every time
    //that a new scene is loaded. You can then compare the scene loaded to your desired
    //scenes and do actions according to the scene loaded.
    private void SceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "SampleScene" && !MainMenu.SampleSceneStartGame) {
            if (MainMenu.SampleSceneFinishedGame) {
                animMalaVrataLijevo.SetBool("Opened", true); 
                if(!source.isPlaying) source.PlayOneShot(clip);
            }
            else{
                
                animMalaVrataLijevo.SetBool("Opened", false); 
            }
            Debug.Log("Pozicija bi trebala biti ispred vrata");
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = PlayerPositionAfterGame1;           // ovdje nesto ne valja

            animMainDoors.SetBool("OpenedMainDoors", true);
            animVrataDvorane.SetBool("OpenedVrataDvorane", true);
        }
        else{
             animMainDoors.SetBool("OpenedMainDoors", false);
            animVrataDvorane.SetBool("OpenedVrataDvorane", false);
        }
           

        if(scene.name == "SampleScene" && MainMenu.SampleSceneStartGame) {
            Info.pritisniZaInfo = true;
            Debug.Log("Pozicija bi trebala bit na startu");
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = StartPlayerPosition;
        }
    }
}