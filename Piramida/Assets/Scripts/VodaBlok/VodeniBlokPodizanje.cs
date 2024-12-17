using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VodeniBlokPodizanje : MonoBehaviour
{
   
    public GameObject najvisiStup;
    public GameObject srednjiStup;
    public GameObject najmanjiStup;

    public AudioClip clip;
    public AudioSource source;

    private int helper = 0;

    // Update is called once per frame
    void Update()
    {
        if(najvisiStup.transform.position.y == -5.5 && najmanjiStup.transform.position.y == -9.5 && srednjiStup.transform.position.y == -7.5){

            transform.position = new Vector3(transform.position.x,(float) -12.25,transform.position.z);

            if (!source.isPlaying && helper == 0){
                helper = 1;
                source.PlayOneShot(clip);
            }
        }
    }
}
