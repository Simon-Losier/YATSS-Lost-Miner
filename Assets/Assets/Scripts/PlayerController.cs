using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;

    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movement.x, 0, movement.y) * Time.deltaTime * speed;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        movement = context.ReadValue<Vector2>();
    }
}
