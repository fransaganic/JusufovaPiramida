using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManagerScript : MonoBehaviour
{
    public double time;
    public double currentTime;

    public GameObject video2;
    // Use this for initialization
    void Start () {
 
    time = gameObject.GetComponent<VideoPlayer> ().clip.length - 0.04;
    }
 
   
    // Update is called once per frame
    void Update () {
        currentTime = gameObject.GetComponent<VideoPlayer> ().time;
        if (currentTime >= time) {
            
            video2.SetActive(true);
        }
    }

}
