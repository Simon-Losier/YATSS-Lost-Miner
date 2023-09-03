using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementDirection = Vector2.zero;
    private float _attack;
    public int speed = 5;
    public GameObject projectile;
    public bool allowShoot = true;
    private bool _fixing = false; // For fixing rails
    private Rigidbody _rigidbody;
    private int _gold = 0;
    private int _steel = 0;
    public int quota = 10;
    private KeyValuePair<string, int> _inventory;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        _rigidbody.velocity = new Vector3(_movementDirection.x, 0, _movementDirection.y) * Time.deltaTime * speed;
        
        // Citation for Vector2 based rotation: https://stackoverflow.com/questions/65752543/gameobject-rotation-based-vector2-direction
        if (!_movementDirection.Equals(Vector2.zero))
        {
            transform.right = new Vector3(_movementDirection.x, 0, _movementDirection.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_attack == 1 && allowShoot)
        {
            Shoot();
            allowShoot = false;
        }

        if (_attack == 0)
        {
            allowShoot = true;
        }

        if (_gold >= quota)
        {
            SceneManager.LoadScene("WinState");
        }
    }

    public bool _isFixing()
    {
        if (_steel > 0)
        {
            return _fixing;
        }

        return false;
    }

    public bool _useSteel()
    {
        if (_steel > 0)
        {
            _steel--;
            return true;
        }

        return false;
    }
    private void Shoot()
    {
        // Create the mining orb
        GameObject instance = Instantiate(projectile, transform.position, transform.rotation);
        instance.transform.right = transform.right;
        instance.GetComponent<MoveForward>().SetDirection(transform.right);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        _attack = context.ReadValue<float>();
    }

    public void OnFix(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value == 1)
        {
            _fixing = true;
        }
        else
        {
            _fixing = false;
        }
    }

    public int GetGold()
    {
        return _gold;
    }

    public int GetSteel()
    {
        return _steel;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GoldIngot"))
        {
            _gold++;
            Destroy(other.gameObject);
            return;
        }
        if (other.gameObject.CompareTag("SteelIngot"))
        {
            _steel++;
            Destroy(other.gameObject);
            return;
        }
        if (other.gameObject.CompareTag("AttackProjectile"))
        {
            SceneManager.LoadScene("GameOverState");
        }
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
