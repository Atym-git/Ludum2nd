using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombatSystem : ACombatSystem
{
    [SerializeField] private float _maxHealth = 35f;
    private float _currHealth;

    [SerializeField] private float _basicDamage = 10f;
     private float _damage;

    //public static PlayerCombatSystem Instance { get; private set; }

    private EnemyCombatSystem _enemyCombatSystem;

    private bool _isWeaponEquipped = false;
    private bool _isEnemyInAttackRange = false;

    [HideInInspector] public bool hasKeyCard = false;

    private void Start()
    {
        _currHealth = _maxHealth;
        _damage = _basicDamage;
        //Instance = this;
    }

    public override void TakeDamage(float damage)
    {
        _currHealth -= damage;
        //Mathf.Lerp(_currHealth, 0, _maxHealth);
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

    public void WeaponEquipped(float damage)
    {
        _damage = _basicDamage + damage;
    }

    public void ArmorEquipped(float health)
    {
        _maxHealth += health;
        _currHealth += health;
    }

    public override void Attack()
    {
        //TODO: Make attack animation with key event that tracks if you hit or not
        //TODO: Animation's key causes event that starts MakeDamage
        MakeDamage();
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
    private void Update()
    {
        if (_isEnemyInAttackRange)
        {
            Attack();
        }
    }
}
