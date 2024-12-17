using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndingScript : MonoBehaviour
{
    public Item SibirskiPlavac;
    public Item amongus;

    // Update is called once per frame
    void Update()
    {
        

   
        if (InventoryManager.items.Contains(SibirskiPlavac)) {
            PlayerPrefs.SetInt("trueEnding", 1);

            if(PlayerPrefs.GetString("trueTimer") == "" ||
             ((float.Parse(PlayerPrefs.GetString("trueTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
             float.Parse(PlayerPrefs.GetString("trueTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
             float.Parse(PlayerPrefs.GetString("trueTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
            {
                PlayerPrefs.SetString("trueTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
            }

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
            SceneManager.LoadScene("TrueEnding");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
}
