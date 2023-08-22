using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cartController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public int speed = 1;
    // Start is called before the first frame update
    public Vector3 direction = new Vector3(5, 0, 0);
    void Start()
    {
           
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(1 * speed, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BrokenRail") || other.gameObject.CompareTag("AttackProjectile"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOverState");
        }
    }
}
