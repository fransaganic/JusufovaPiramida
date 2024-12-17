using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupoviPoint : MonoBehaviour
{
    [SerializeField]
    GameObject poruka;


    public GameObject vrata;



    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            
            
            poruka.SetActive(true);
            Debug.Log("Ovo je proslo");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("Player")) {
            poruka.SetActive(false);
        }
    }
}

