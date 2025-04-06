using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO",
menuName = "SO/Enemy/New Enemy")]
public class EnemySO : APrefabInstance
{
    [field: SerializeField]
    public Sprite EnemySprite { get; private set; }
    [field: SerializeField]
    public float EnemyMovementSpeed { get; private set; }
    [field: SerializeField]
    public float EnemyDamage { get; private set; }
    [field: SerializeField]
    public float EnemyHealth { get; private set; }

    public override void SetupInstance(GameObject prefabInstance)
    {
        EnemyCombatSystem enemyCombat = prefabInstance.GetComponent<EnemyCombatSystem>();
        EnemyMovement enemyMovement = prefabInstance.GetComponent<EnemyMovement>();

        prefabInstance.GetComponent<SpriteRenderer>().sprite = EnemySprite;
        enemyMovement.MoveSpeed = EnemyMovementSpeed;
        enemyCombat = new EnemyCombatSystem(EnemyDamage, EnemyHealth);
    }
}
