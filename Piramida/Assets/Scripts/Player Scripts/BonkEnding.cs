using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BonkEnding : MonoBehaviour
{
    public Item amongus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -200){
            PlayerPrefs.SetInt("bonkEnding", 1);

            if(PlayerPrefs.GetString("bonkTimer") == "" ||
             ((float.Parse(PlayerPrefs.GetString("bonkTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
             float.Parse(PlayerPrefs.GetString("bonkTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
             float.Parse(PlayerPrefs.GetString("bonkTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
            {
                PlayerPrefs.SetString("bonkTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
            }

            if(InventoryManager.items.Contains(amongus)){
                if(PlayerPrefs.GetString("susTimer") == "" ||
                ((float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
                {
                    PlayerPrefs.SetString("susTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
                }

                PlayerPrefs.SetInt("susEnding", 1);
            } 
            SceneManager.LoadScene("BonkEnding");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
