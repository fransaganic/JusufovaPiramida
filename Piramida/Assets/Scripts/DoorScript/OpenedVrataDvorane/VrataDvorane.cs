using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrataDvorane : MonoBehaviour{
    [SerializeField]
    private Animator anim;

    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            if(!source.isPlaying && anim.GetBool("OpenedVrataDvorane") == false) source.PlayOneShot(clip);
            anim.SetBool("OpenedVrataDvorane", true);
        }
    }
}
