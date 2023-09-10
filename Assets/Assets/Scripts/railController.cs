using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RailController : MonoBehaviour
{
    public GameObject fixedRail;
    public bool isBroken;
    private static List<GameObject> _rails = new List<GameObject>();
    private void OnEnable()
    {
        if (isBroken)
        {
            _rails.Add(this.gameObject);
        }
        
    }

    private void OnDisable()
    {
        if (isBroken)
        {
            _rails.Remove(this.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player._isFixing())
            {
                Debug.Log("Fixing rail!");
                player._useSteel();
                FixRail();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Cart"))
            {
                SceneManager.LoadScene("GameOverState");
            }
        }
    }

    private void FixRail()
    {
        Instantiate(fixedRail, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
