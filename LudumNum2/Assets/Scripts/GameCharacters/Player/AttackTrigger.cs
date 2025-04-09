using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private EnemyCombatSystem _enemyCombatSystem;
    private PlayerCombatSystem _playerCombatSystem;
    private Breakables _breakables;

    [SerializeField] private bool _isRightTrigger;

    private void Start()
    {
        _playerCombatSystem = transform.parent.GetComponent<PlayerCombatSystem>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyCombatSystem>(out _enemyCombatSystem))
        {
            _playerCombatSystem.AssignEnemyCombat(_enemyCombatSystem);
            _playerCombatSystem.AssignTrigger(_isRightTrigger);
            _playerCombatSystem.isEnemyInAttackRange = true;
        }
        else if (collision.gameObject.TryGetComponent<Breakables>(out _breakables))
        {
            _playerCombatSystem.AssignBreakables(_breakables);
            _playerCombatSystem.isBreakableInAttackRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyCombatSystem>())
        {
            _playerCombatSystem.isEnemyInAttackRange = false;
        }
        else if (collision.gameObject.GetComponent<Breakables>())
        {
            _playerCombatSystem.isBreakableInAttackRange = false;
        }
    }
}
