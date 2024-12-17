using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimersManager : MonoBehaviour
{
    
    public  TextMeshProUGUI goodTimer;
    public  TextMeshProUGUI squashTimer;
    public  TextMeshProUGUI bonkTimer;
    public  TextMeshProUGUI trueTimer;
    public  TextMeshProUGUI susTimer;

    private void Awake(){

       goodTimer.text = PlayerPrefs.GetString("goodTimer");
       squashTimer.text = PlayerPrefs.GetString("squashTimer");
       bonkTimer.text = PlayerPrefs.GetString("bonkTimer");
       trueTimer.text = PlayerPrefs.GetString("trueTimer");
       susTimer.text = PlayerPrefs.GetString("susTimer");
    }
}
