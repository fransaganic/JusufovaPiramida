using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupRaycast : MonoBehaviour
{
    Ray ray;


    void Update(){
        if (!PauzaSkripta.isPaused){
        ray = new Ray(transform.position + new Vector3(1,0,0), transform.forward);
        CheckForColliders();
        }
        
    }

     void CheckForColliders (){
        if(Physics.Raycast(ray, out RaycastHit hit, 1)){
           
            if((hit.collider.gameObject.tag == "Stup")){
                
                if(Input.GetButtonDown("E") == true){
                
                if(hit.collider.gameObject.transform.position.y == -5.5){
                    hit.collider.gameObject.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x,(float) -7.5, hit.collider.gameObject.transform.position.z );
                }else if(hit.collider.gameObject.transform.position.y == -7.5){
                        hit.collider.gameObject.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x,(float) -9.5, hit.collider.gameObject.transform.position.z );
                }else {
                    hit.collider.gameObject.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x,(float) -5.5, hit.collider.gameObject.transform.position.z );
                }
                
                }
        
            
            }
        }
        
    }
}
