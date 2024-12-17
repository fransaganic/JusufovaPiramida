using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlocica : MonoBehaviour
{
    Ray ray;

    public ArrowTrap arrowTrap1;
    public ArrowTrap arrowTrap2;
    public ArrowTrap arrowTrap3;
    public ArrowTrap arrowTrap4;
    public ArrowTrap arrowTrap5;
    public ArrowTrap arrowTrap6;
    public ArrowTrap arrowTrap7;
    public ArrowTrap arrowTrap8;
    public ArrowTrap arrowTrap9;
    public ArrowTrap arrowTrap10;
    public ArrowTrap arrowTrap11;
    public ArrowTrap arrowTrap12;

    public int helper = 0;

    public AudioClip clip;

    public AudioSource source;

    
    private int haltCekanje = 1;
    void Start(){
       
    }
    void Update(){
        if (!PauzaSkripta.isPaused){
        ray = new Ray(transform.position + new Vector3(0,1,0), transform.up * -1);
        CheckForColliders();
        }
        
    }
    void CheckForColliders (){
        if(Physics.Raycast(ray, out RaycastHit hit, 1)){
            

            if((hit.collider.gameObject.tag == "KrivaPlocica") || (hit.collider.gameObject.tag == "Dno" ) || (hit.collider.gameObject.tag == "Water" )){
            
            if(helper == 0){
                helper = 1;
                if (hit.collider.gameObject.tag == "Dno") haltCekanje = 0;
                StartCoroutine(Waiter(haltCekanje,new  Vector3(-4501, -7, 130)));
                helper = 0;
            }
            }

            if(hit.collider.gameObject.tag == "KrivaPlocica"){
            arrowTrap1.udarac = 1;
            arrowTrap2.udarac = 1;
            arrowTrap3.udarac = 1;
            arrowTrap4.udarac = 1;
            arrowTrap5.udarac = 1;
            arrowTrap6.udarac = 1;
            arrowTrap7.udarac = 1;
            arrowTrap8.udarac = 1;
            arrowTrap9.udarac = 1;
            arrowTrap10.udarac = 1;
            arrowTrap11.udarac = 1;
            arrowTrap12.udarac = 1;
            }
            else{
            arrowTrap1.udarac = 0;
            arrowTrap2.udarac = 0;
            arrowTrap3.udarac = 0;
            arrowTrap4.udarac = 0;
            arrowTrap5.udarac = 0;
            arrowTrap6.udarac = 0;
            arrowTrap7.udarac = 0;
            arrowTrap8.udarac = 0;
            arrowTrap9.udarac = 0;
            arrowTrap10.udarac = 0;
            arrowTrap11.udarac = 0;
            arrowTrap12.udarac = 0;
            }

            if(hit.collider.gameObject.tag == "Lava"){
                if(helper == 0){
                helper = 1;
                StartCoroutine(Waiter(1, new Vector3(-4501, 0, 5)));
                helper = 0;
            }
            }
        }
    }

    IEnumerator Waiter(int halt, Vector3 vector){
        yield return new WaitForSeconds(halt);
        if (!source.isPlaying)source.PlayOneShot(clip);
        if (transform.position != vector) transform.position = vector;
        
        
    }
    
}
