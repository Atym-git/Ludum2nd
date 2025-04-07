using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : ACombatSystem
{
    public float maxHealth = 30f;
    private float _currHealth;

    public float damage = 150f;

    private PlayerCombatSystem _playerCombatSystem;

    private bool _isPlayerInAttackRange = false;

    private float _attackDelay;

    //public EnemyCombatSystem(float maxHealth, float damage)
    //{
    //    _maxHealth = maxHealth;
    //    _damage = damage;
    //}

    private void Start()
    {
        maxHealth = _currHealth;
    }

    public override void TakeDamage(float damage)
    {
        _currHealth -= damage;
        Mathf.Lerp(_currHealth, 0, maxHealth);
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
        //StartCoroutine(AttackDelay(_attackDelay));
        MakeDamage();
    }

    private IEnumerator AttackDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public override void MakeDamage()
    {
        //if (_isPlayerInAttackRange)
        //{
            _playerCombatSystem.TakeDamage(damage);
        //}
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<PlayerCombatSystem>())
        //{
        //    _playerCombatSystem = collision.gameObject.GetComponent<PlayerCombatSystem>();
        //    _isPlayerInAttackRange = true;
        //}
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<PlayerCombatSystem>())
        //{
        //    _isPlayerInAttackRange = false;
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCombatSystem>())
        {
            //_isPlayerInAttackRange = true;
            _playerCombatSystem = collision.gameObject.GetComponent<PlayerCombatSystem>();
            MakeDamage();
        }
    }
    private void FixedUpdate()
    {
        if (_isPlayerInAttackRange)
        {
            Attack();
        }
    }

}
