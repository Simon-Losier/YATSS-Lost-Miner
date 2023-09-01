using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    public GameObject player;
    private PlayerController _playerController;
    private TextMeshProUGUI _textMeshPro;
    
    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string message = "Quota: " + _playerController.quota + " Gold \n";
        message = message + "GOLD: " + _playerController.GetGold() + "\n";
        message = message + "STEEL: " + _playerController.GetSteel() + "\n";
        _textMeshPro.text = message;
    }
}
