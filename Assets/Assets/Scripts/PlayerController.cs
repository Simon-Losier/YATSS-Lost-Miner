using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementDirection = Vector2.zero;
    private float attack;
    public int speed = 5;
    public GameObject projectile;
    public bool allowShoot = true;
    private bool fixing = false; // For fixing rails
    private Rigidbody _rigidbody;
    private int gold = 0;
    private int steel = 0;
    public int quota = 10;
    private KeyValuePair<string, int> inventory;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        _rigidbody.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * Time.deltaTime * speed;
        
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

        if (gold >= quota)
        {
            SceneManager.LoadScene("WinState");
        }
    }

    public bool isFixing()
    {
        if (steel > 0)
        {
            return fixing;
        }

        return false;
    }

    public bool useSteel()
    {
        if (steel > 0)
        {
            steel--;
            return true;
        }

        return false;
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

    public int getGold()
    {
        return gold;
    }

    public int getSteel()
    {
        return steel;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GoldIngot"))
        {
            gold++;
            Destroy(other.gameObject);
            return;
        }
        if (other.gameObject.CompareTag("SteelIngot"))
        {
            steel++;
            Destroy(other.gameObject);
            return;
        }
        if (other.gameObject.CompareTag("AttackProjectile"))
        {
            SceneManager.LoadScene("GameOverState");
        }
    }

    public void onExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
