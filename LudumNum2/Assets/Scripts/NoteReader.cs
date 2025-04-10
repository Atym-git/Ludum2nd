using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _helpingTMP;

    [SerializeField] private GameObject _notePanel;

    [SerializeField] private string _helpingTextValue;

    private PlayerInput _playerActions;

    private bool _isInsideTrigger = false;

    private void Start()
    {
        Bind();
        _helpingTMP.text = _helpingTextValue;
    }

    private void Bind()
    {
        _playerActions = new PlayerInput();
        _playerActions.Enable();
        _playerActions.Player.Interact.performed += ReadNotes;
    }

    private void ReadNotes(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (_isInsideTrigger)
        {
            _notePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>())
        {
            _helpingTMP.gameObject.SetActive(true);
            _isInsideTrigger = true;
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>())
        {
            _helpingTMP.gameObject.SetActive(false);
            _isInsideTrigger = false;
        }
    }

    private void OnDestroy()
    {
        _playerActions.Disable();
        _playerActions.Player.Interact.performed -= ReadNotes;
    }
}
