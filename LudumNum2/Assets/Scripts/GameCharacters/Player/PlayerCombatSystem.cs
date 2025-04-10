using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCombatSystem : ACombatSystem
{
    [SerializeField] private float _maxHealth = 35f;
    private float _currHealth;

    [SerializeField] private float _basicDamage = 10f;
    private float _damage;

    [SerializeField] private KeyCode _attackKey = KeyCode.Q;

    private Animator _animator;
    private SpriteRenderer _sr;
    private EnemyCombatSystem _enemyCombatSystem;
    private Breakables _breakables;

    [SerializeField] private GameObject _deathPanel;

    private bool _isWeaponEquipped = false;
    public bool isEnemyInAttackRange = false;
    public bool isBreakableInAttackRange = false;
    private bool isRightTrigger;

    public bool hasKeyCard = false;

    private const string _animAttackName = "Attack";

    private void Start()
    {
        _currHealth = _maxHealth;
        _damage = _basicDamage;
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage(float damage)
    {
        _currHealth -= damage;
        if (!IsAlive())
        {
            Time.timeScale = 0f;
            _deathPanel.SetActive(true);
            //BackToCheckPoint();
        }
    }

    public void BackToCheckPoint()
    {
        transform.position = CheckPointManager.BackToCheckPoint();
        Time.timeScale = 1f;
        _deathPanel.SetActive(false);
        _currHealth = _maxHealth;
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
        if (isRightTrigger != _sr.flipX)
        {
            if (isEnemyInAttackRange)
            {
                _enemyCombatSystem.TakeDamage(_damage);
            }
            else if (isBreakableInAttackRange)
            {
                _breakables.BreakBreakables();
            }
        }
        //if (isEnemyInAttackRange)
        //{
        //    _enemyCombatSystem.TakeDamage(_damage);
        //}
        //else if (isBreakableInAttackRange)
        //{
        //    _breakables.BreakBreakables();
        //}
    }

    public void AssignTrigger(bool isRightTrigger) => this.isRightTrigger = isRightTrigger;
    public void AssignEnemyCombat(EnemyCombatSystem enemyCombat) => _enemyCombatSystem = enemyCombat;
    public void AssignBreakables(Breakables breakables) => _breakables = breakables;

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey))
        {
            _animator.SetTrigger(_animAttackName);
        }
    }
}
