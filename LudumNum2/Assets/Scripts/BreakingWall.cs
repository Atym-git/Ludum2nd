using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakingWall : MonoBehaviour
{
    private PlayerInput _playerActions;

    private bool _isInsideTrigger = false;

    private TextMeshProUGUI _wallTMP;

    private string _wallText = "Press E to open a door";

    [SerializeField] private PlayerCombatSystem _playerCombatSystem;

    private void Awake()
    {
        _wallTMP = GetComponentInChildren<TextMeshProUGUI>();
        _wallTMP.text = _wallText;
        _wallTMP.gameObject.SetActive(false);
        Bind();
    }

    private void Bind()
    {
        _playerActions = new PlayerInput();
        _playerActions.Enable();
        _playerActions.Player.Interact.performed += BreakWall;
    }

    private void BreakWall(InputAction.CallbackContext context)
    {
        if (_playerCombatSystem != null)
        {
            Debug.Log("Inside Trigger" + _isInsideTrigger);
            Debug.Log($"Player Combat System: {_playerCombatSystem}");
            if (_isInsideTrigger && _playerCombatSystem.hasKeyCard)
            {
                Debug.Log($"Player Combat System: {_playerCombatSystem}");
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>())
        {
            if (_playerCombatSystem == null)
            {
                _playerCombatSystem = collision.GetComponent<PlayerCombatSystem>();
            }
            _isInsideTrigger = true;
            _wallTMP.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>() != null)
        {
            _isInsideTrigger = false;
            _wallTMP.gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        if (_playerCombatSystem != null)
        {
            _playerCombatSystem.hasKeyCard = false;
        }
        _playerActions.Disable();
        _playerActions.Player.Interact.performed -= BreakWall;
    }
}
