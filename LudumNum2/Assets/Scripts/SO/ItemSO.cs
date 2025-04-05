using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", 
menuName = "SO/Item/New Item")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }
    [field: SerializeField]
    public GameObject AffectedObject { get; private set; }
    [field: SerializeField]
    public float EquipmentDamage { get; private set; }
    [field: SerializeField]
    public float EquipmentHealth { get; private set; }
}
