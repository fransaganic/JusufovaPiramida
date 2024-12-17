using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    public GameObject projectile;

    public Transform spawnLocation;

    public Quaternion spawnRotation;

    public float spawnTime = 0.5f;

    public float timeSinceSpawned = 0.5f;

    public int udarac;

    public AudioClip clip;
    public AudioSource source;
 
    // Start is called before the first frame update
    void Start()
    {
        udarac = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauzaSkripta.isPaused){
        if(udarac > 0){
            timeSinceSpawned += Time.deltaTime;

            if(timeSinceSpawned >= spawnTime){
                source.PlayOneShot(clip);
                Instantiate(projectile, spawnLocation.position, spawnRotation * Quaternion.Euler(90, 0, 180) );
                timeSinceSpawned = 0;
            }
        }else{
            timeSinceSpawned = 0.5f;
        }
        }
    }
}
