using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACombatSystem : MonoBehaviour
{
    public abstract void TakeDamage(float damage);

    public abstract bool IsAlive();

    public abstract void Attack();
}
