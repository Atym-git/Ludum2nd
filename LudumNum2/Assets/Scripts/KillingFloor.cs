using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillingFloor : MonoBehaviour
{
    [SerializeField] private Animator _deathFloorAnimation;

    private PlayerCombatSystem _combatSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCombatSystem>(out _combatSystem))
        {
            //TODO : Play death floor animation
            StartCoroutine(Delay(0.5f));
            _combatSystem.TakeDamage(1000);
        }
    }
    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
