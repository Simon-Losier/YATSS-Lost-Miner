using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class railController : MonoBehaviour
{
    public GameObject fixedRail;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player.isFixing())
            {
                Debug.Log("Fixing rail!");
                player.useSteel();
                fixRail();
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

    private void fixRail()
    {
        Instantiate(fixedRail, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
