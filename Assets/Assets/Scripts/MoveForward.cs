using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed = 200;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = _direction * speed * Time.deltaTime;
    }
}
