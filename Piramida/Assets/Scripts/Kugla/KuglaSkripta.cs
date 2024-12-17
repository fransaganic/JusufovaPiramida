using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KuglaSkripta : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public Item amongus;
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {

            if(PlayerPrefs.GetString("squashTimer") == "" ||
             ((float.Parse(PlayerPrefs.GetString("squashTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
             float.Parse(PlayerPrefs.GetString("squashTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
             float.Parse(PlayerPrefs.GetString("squashTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
            {
                PlayerPrefs.SetString("squashTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
            }

            
            if(!source.isPlaying) source.PlayOneShot(clip);
            PlayerPrefs.SetInt("squashEnding", 1);

            if(InventoryManager.items.Contains(amongus)){
                PlayerPrefs.SetInt("susEnding", 1);

                if(PlayerPrefs.GetString("susTimer") == "" ||
                ((float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
                {
                    PlayerPrefs.SetString("susTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
                }
            } 
            SceneManager.LoadScene("SquashEnding");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }      
    }  
}

