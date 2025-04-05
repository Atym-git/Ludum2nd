using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MindRead : MonoBehaviour
{
    private PlayerInput _playerActions;

    private bool _isPlayerInsideTrigger = false;

    private GameObject _mindReadingPanel;

    private void Start()
    {
        Bind();
    }

    private void Bind()
    {
        _playerActions = new PlayerInput();
        _playerActions.Enable();
        _playerActions.Player.Interact.performed += MindReading;
    }

    private void MindReading(InputAction.CallbackContext context)
    {
        if (_isPlayerInsideTrigger)
        {
            _mindReadingPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = false;
        }
    }
}
