using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

public class MenuController : MonoBehaviour
{
    public void OnStart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("PlayState");
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
