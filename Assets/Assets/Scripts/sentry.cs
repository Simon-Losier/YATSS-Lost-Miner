using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentry : MonoBehaviour
{
    private int health = 3;
    private int shootIntervalSec = 2;

    public GameObject projectile;
    
    void Start()
    {
        hit();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        
        // TODO: Automating shooting of the projectile
    }

    private void spawnProjectile()
    {
        Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
    
    private void hit()
    {
        health--;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            hit();
        }
    }
}
