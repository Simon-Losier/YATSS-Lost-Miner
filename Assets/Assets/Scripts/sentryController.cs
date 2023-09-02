using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryController : MonoBehaviour
{
    public int health = 3;
    public float shootIntervalSec = 2f;
    public GameObject projectile;

    // CITATION: Learned about coroutines here: https://stackoverflow.com/questions/61439740/how-can-i-make-an-action-repeat-every-x-seconds-with-timer-in-c
    IEnumerator shootInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootIntervalSec);
            spawnProjectile();
        }
    }
    
    void Start()
    {
        StartCoroutine(shootInterval());
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
        Debug.Log("Spawn projectile");
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y+1.3f, this.transform.position.z-0.7f);
        GameObject instance = Instantiate(projectile, position, Quaternion.identity);
        instance.transform.right = -instance.transform.forward;
        instance.GetComponent<moveForward>().SetDirection(-instance.transform.forward);
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
