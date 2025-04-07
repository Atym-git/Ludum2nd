using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private EnemyCombatSystem _enemyCombatSystem;
    private PlayerCombatSystem _playerCombatSystem;

    private void Start()
    {
        _playerCombatSystem = transform.parent.GetComponent<PlayerCombatSystem>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyCombatSystem>(out _enemyCombatSystem))
        {
            _playerCombatSystem.AssignEnemyCombat(_enemyCombatSystem);
            _playerCombatSystem.isEnemyInAttackRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyCombatSystem>())
        {
            _playerCombatSystem.isEnemyInAttackRange = false;
        }
    }
}
