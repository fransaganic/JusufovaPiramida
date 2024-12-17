using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    
    public TextMeshProUGUI tekst;
    float minutes;
    float seconds;
    // Update is called once per frame
     
    void Update()
    {
        
        if(ToggleScript.timerVisible) {
            tekst.enabled = true;
            
        }
        else{
            tekst.enabled = false;
        }

        MainMenu.currentTime += Time.deltaTime;
        minutes = Mathf.FloorToInt( MainMenu.currentTime / 60);
        seconds = Mathf.FloorToInt( MainMenu.currentTime % 60);
        tekst.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
