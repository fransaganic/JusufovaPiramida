using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }
    
    private void OnMouseDown()
    {
        float minDist=4;
        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if(dist < minDist)
        {
        Pickup();
        }
    }

}
