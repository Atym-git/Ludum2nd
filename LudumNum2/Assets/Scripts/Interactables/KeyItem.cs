using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyItem : MonoBehaviour
{
    private bool _isPlayerInsideTrigger = false;
    private bool _isPicked = false;

    private PlayerInput _playerActions;

    //Equipment items
    private float _equipmentDamage;

    private float _equipmentHealth;

    //Key item
    [SerializeField] private GameObject _affectedObject;
    private TextMeshProUGUI _itemTMP;

    [SerializeField] private string _TMPValue;

    private PlayerCombatSystem _playerCombatSystem;

    private void Start()
    {
        _itemTMP = GetComponentInChildren<TextMeshProUGUI>();
        Bind();
        _itemTMP.text = _TMPValue;
    }

    private void Bind()
    {
        _playerActions = new PlayerInput();
        _playerActions.Enable();
        _playerActions.Player.Interact.performed += ItemPicked;
    }

    private void ItemPicked(InputAction.CallbackContext context)
    {
        if (_isPlayerInsideTrigger)
        {
            _isPicked = true;
            _playerCombatSystem.WeaponEquipped(_equipmentDamage);
            _playerCombatSystem.ArmorEquipped(_equipmentHealth);
            if (_affectedObject != null)
            {
                Destroy(_affectedObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = true;
            _itemTMP.gameObject.SetActive(true);
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _isPlayerInsideTrigger = false;
            _itemTMP.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        _playerActions.Disable();
        _playerActions.Player.Interact.performed -= ItemPicked;
    }
}
