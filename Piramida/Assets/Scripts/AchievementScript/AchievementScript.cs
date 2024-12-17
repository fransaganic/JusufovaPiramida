using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour
{
    [SerializeField] public string achievementType;

    private RawImage image;

    private void Awake(){
        image = GetComponent<RawImage>();
        checkIfAchievementIsUnlocked();
    }
    public void checkIfAchievementIsUnlocked(){

        if(PlayerPrefs.GetInt(achievementType) == 0){
            image.color = Color.black;
        }
        else{
            image.color = Color.white;
            
        }
    }

    
}
