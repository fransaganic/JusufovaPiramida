using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed = 1f;

    public float timeToLive = 2f;

    private float timeSinceSpawned = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * transform.right  * Time.deltaTime * -1;

        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned > timeToLive){
            Destroy(gameObject);
        }
    }
}
