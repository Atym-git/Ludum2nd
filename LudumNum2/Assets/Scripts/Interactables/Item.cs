using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    private bool _isPlayerInsideTrigger = false;
    private bool _isPicked = false;

    private PlayerInput _playerActions;

    //Equipment items
    public float equipmentDamage;

    public float equipmentHealth;

    //Key item
    public bool isKeyCard;
    private TextMeshProUGUI _itemTMP;

    [SerializeField] private string _TMPValue;

    [SerializeField] private PlayerCombatSystem _playerCombatSystem;

    private void Start()
    {
        _itemTMP = GetComponentInChildren<TextMeshProUGUI>();
        _itemTMP.gameObject.SetActive(false);
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
            Debug.Log(equipmentDamage);
            _playerCombatSystem.WeaponEquipped(equipmentDamage);
            _playerCombatSystem.ArmorEquipped(equipmentHealth);
            _playerCombatSystem.hasKeyCard = isKeyCard;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>())
        {
            _playerCombatSystem = collision.GetComponent<PlayerCombatSystem>();
            _isPlayerInsideTrigger = true;
            _itemTMP.gameObject.SetActive(true);
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCombatSystem>())
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
