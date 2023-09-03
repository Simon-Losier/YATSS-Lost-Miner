using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class OreController : MonoBehaviour
{
    public string oreType = "gold"; // Possible: gold, steel
    [FormerlySerializedAs("Ingot")] public GameObject ingot;
    public int health = 2;
    
    void Start()
    {
        
    }

    public void Hit()
    {
        Debug.Log("I was hit D:");
        health = Math.Min(health, health - 1); 
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Hit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Drop ore item
            Instantiate(ingot, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0);
        }
    }
}
