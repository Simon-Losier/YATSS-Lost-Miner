using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public int speed = 5;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = transform.right * speed * Time.deltaTime;
    }
}
