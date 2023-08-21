using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementDirection = Vector2.zero;
    private float attack;
    public int speed = 5;
    public GameObject projectile;
    public bool allowShoot = true;
    private bool fixing = false; // For fixing rails

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * Time.deltaTime * speed;
        
        // Citation for Vector2 based rotation: https://stackoverflow.com/questions/65752543/gameobject-rotation-based-vector2-direction
        if (!movementDirection.Equals(Vector2.zero))
        {
            transform.right = new Vector3(movementDirection.x, 0, movementDirection.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (attack == 1 && allowShoot)
        {
            shoot();
            allowShoot = false;
        }

        if (attack == 0)
        {
            allowShoot = true;
        }
    }

    public bool isFixing()
    {
        return fixing;
    }
    private void shoot()
    {
        // Create the mining orb
        float distanceFromPlayer = 0.2f;
        GameObject instance = Instantiate(projectile, transform.position, transform.rotation);
        instance.transform.right = transform.right;
    }
    public void onMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        attack = context.ReadValue<float>();
    }

    public void onFix(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value == 1)
        {
            fixing = true;
        }
        else
        {
            fixing = false;
        }
    }
}
