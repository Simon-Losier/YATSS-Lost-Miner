using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["movement"];
    }

    private void Update()
    {
        //Vector2 move = _moveAction.ReadValue<Vector2>();
        //Debug.Log(move);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        Debug.Log(move);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }

}
