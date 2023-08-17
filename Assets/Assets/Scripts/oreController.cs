using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreController : MonoBehaviour
{
    public string[] oreType = {"gold", "steel"};

    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void hit()
    {
        Debug.Log("I was hit D:");
        health = Math.Min(health, health - 1);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
