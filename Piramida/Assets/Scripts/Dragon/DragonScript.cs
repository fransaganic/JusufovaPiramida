using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public GameObject vrata;

    public AudioSource source;
    public AudioClip clip;

    public void TakeDamage(int damageAmount){

        HP -= damageAmount;
        if(HP <= 0)
        {
            vrata.transform.position = new Vector3 (vrata.transform.position.x,vrata.transform.position.y - 100, vrata.transform.position.z);
            if(!source.isPlaying) source.PlayOneShot(clip);
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            
        }
        else{
            animator.SetTrigger("damage");
        }
    }

    public int GetHP(){
        return HP;
    }
}
