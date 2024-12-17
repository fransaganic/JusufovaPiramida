using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
  public static bool timerVisible;
  public int brojPlayerPref;

  public Toggle toggle;
  private void Update(){
    brojPlayerPref = PlayerPrefs.GetInt("timer");
    if(brojPlayerPref == 1){
        timerVisible = true;
        toggle.isOn = true;
    }
    else{
        timerVisible = false;
        toggle.isOn = false;
    }
  }
  public void setVisibility(bool isVisible){

    if(isVisible){
        PlayerPrefs.SetInt("timer", 1);
    }
    else{
        PlayerPrefs.SetInt("timer", 0);
    }

    timerVisible = isVisible;
  }  
}
