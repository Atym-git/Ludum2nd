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

    private Animator _animator;
    private EnemyCombatSystem _enemyCombatSystem;
    private Breakables _breakables;
    private SpriteRenderer _sr;

    private bool _isWeaponEquipped = false;
    public bool isEnemyInAttackRange = false;
    public bool isBreakableInAttackRange = false;
    private bool _isRightTrigger;

    public bool hasKeyCard = false;

    private const string _animAttackName = "Attack";

    private void Start()
    {
        _currHealth = _maxHealth;
        _damage = _basicDamage;
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
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
        if (_isRightTrigger != _sr.flipX)
        {

        }
        if (isEnemyInAttackRange)
        {
            _enemyCombatSystem.TakeDamage(_damage);
        }
        else if (isBreakableInAttackRange)
        {
            _breakables.BreakBreakables();
        }
    }

    public void AssignTriggerSide(bool isRightTrigger) => _isRightTrigger = isRightTrigger;

    public void AssignEnemyCombat(EnemyCombatSystem enemyCombat) => _enemyCombatSystem = enemyCombat;
    public void AssignBreakables(Breakables breakables) => _breakables = breakables;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(_animAttackName);
        }
    }

    //public override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<EnemyCombatSystem>())
    //    {
    //        _enemyCombatSystem = collision.gameObject.GetComponent<EnemyCombatSystem>();
    //        isEnemyInAttackRange = true;
    //    }
    //}

    //public override void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<EnemyCombatSystem>())
    //    {
    //        isEnemyInAttackRange = false;
    //    }
    //}
}
