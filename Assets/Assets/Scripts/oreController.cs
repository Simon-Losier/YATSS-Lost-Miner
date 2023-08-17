using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class oreController : MonoBehaviour
{
    public string oreType = "gold"; // Possible: gold, steel
    public GameObject Ingot;
    public int health = 2;
    
    void Start()
    {
        
    }

    public void hit()
    {
        Debug.Log("I was hit D:");
        health = Math.Min(health, health - 1); 
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            hit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Drop ore item
            Instantiate(Ingot, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0);
        }
    }
}
