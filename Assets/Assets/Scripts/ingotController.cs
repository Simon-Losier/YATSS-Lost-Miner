using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingotController : MonoBehaviour
{

    public string oreType = "gold"; // Possible: gold, steel

    private void pickup()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickup();
        }
    }
}
