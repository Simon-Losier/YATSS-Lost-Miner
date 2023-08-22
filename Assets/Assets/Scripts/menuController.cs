using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

public class menuController : MonoBehaviour
{
    public void onStart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("PlayState");
    }

    public void onExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
