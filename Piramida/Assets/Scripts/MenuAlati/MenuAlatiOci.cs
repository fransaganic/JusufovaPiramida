using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAlatiOci : MonoBehaviour
{
     private float time = 0.0f;
     public float interpolationPeriod = 0.1f;

    public GameObject oko1;
    public GameObject oko2;
 void Update () {
     time += Time.deltaTime;
 
     if (time >= interpolationPeriod) {
         time = 0.0f;
        if(oko1.activeSelf == false){
            oko1.SetActive(true);
            oko2.SetActive(true);
        }
        else{
            oko1.SetActive(false);
            oko2.SetActive(false);
        }
        
     }
 }
}
