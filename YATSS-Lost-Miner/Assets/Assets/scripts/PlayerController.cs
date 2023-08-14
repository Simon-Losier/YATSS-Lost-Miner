using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _movementAction;
    private InputAction _attackAction;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
        _attackAction = _playerInput.actions["Attack"];
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _movementAction.ReadValue<Vector2>();
        Debug.Log(move);
        Debug.Log(_movementAction.ReadValue<bool>());
    }
}
