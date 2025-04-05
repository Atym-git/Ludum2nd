using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : ACombatSystem
{
    private float _maxHealth = 30f;
    private float _currHealth;

    private float _damage = 7.5f;

    private PlayerCombatSystem _playerCombatSystem;

    private bool _isPlayerInAttackRange = false;

    private void Start()
    {
        _maxHealth = _currHealth;
    }

    public override void TakeDamage(float damage)
    {
        _currHealth -= damage;
        Mathf.Lerp(_currHealth, 0, _maxHealth);
        if (!IsAlive())
        {
            //TODO: Play enemy death animation
            Destroy(gameObject);
        }
    }

    public override bool IsAlive()
    {
        return _currHealth > 0;
    }

    public override void Attack()
    {
        //TODO: Make attack animation with key event that tracks if you hit or not
        //TODO: Animation's key causes event that starts MakeDamage
    }

    public override void MakeDamage()
    {
        if (_isPlayerInAttackRange)
        {
            _playerCombatSystem.TakeDamage(_damage);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCombatSystem>())
        {
            _playerCombatSystem = collision.gameObject.GetComponent<PlayerCombatSystem>();
            _isPlayerInAttackRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCombatSystem>())
        {
            _isPlayerInAttackRange = false;
        }
    }

}
