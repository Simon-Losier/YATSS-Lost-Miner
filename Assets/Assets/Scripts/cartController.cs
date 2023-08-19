using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cartController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 direction = new Vector3(5, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BrokenRail") || other.gameObject.CompareTag("AttackProjectile"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }
}
