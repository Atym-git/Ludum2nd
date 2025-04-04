using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombatSystem : ACombatSystem
{
    [SerializeField] private float _maxHealth = 35f;
    private float _currHealth;

    [SerializeField] private float _damage;

    public static PlayerCombatSystem Instance { get; private set; }

    private bool _isEnemyInAttackRange = false;

    private EnemyCombatSystem _enemyCombatSystem;

    private void Start()
    {
        _currHealth = _maxHealth;
        Instance = this;
    }

    public override void TakeDamage(float damage)
    {
        _currHealth -= damage;
        Mathf.Lerp(_currHealth, 0, _maxHealth);
        if (!IsAlive())
        {
            //TODO: Play player death animation
            _currHealth = _maxHealth;
            transform.position = CheckPointManager.BackToCheckPoint();
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
        if (_isEnemyInAttackRange)
        {
            _enemyCombatSystem.TakeDamage(_damage);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyCombatSystem>())
        {
            _enemyCombatSystem = collision.gameObject.GetComponent<EnemyCombatSystem>();
            _isEnemyInAttackRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyCombatSystem>())
        {
            _isEnemyInAttackRange = false;
        }
    }

}
