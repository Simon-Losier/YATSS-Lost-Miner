using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOnCollision : MonoBehaviour
{
    public string excludeTag = "Sentry";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(excludeTag))
        {
            Destroy(this.gameObject);
        }
    }
}
