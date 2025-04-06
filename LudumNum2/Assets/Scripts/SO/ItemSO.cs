using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", 
menuName = "SO/Item/New Item")]
public class ItemSO : APrefabInstance
{
    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }
    [field: SerializeField]
    public GameObject AffectedObject { get; private set; }
    [field: SerializeField]
    public float EquipmentDamage { get; private set; }
    [field: SerializeField]
    public float EquipmentHealth { get; private set; }

    public override void SetupInstance(GameObject prefabInstance)
    {
        Item item = prefabInstance.GetComponent<Item>();

        prefabInstance.GetComponent<SpriteRenderer>().sprite = ItemSprite;
        if (AffectedObject != null)
        {
            item.affectedObject = AffectedObject;
        }
        item.equipmentDamage = EquipmentDamage;
        item.equipmentHealth = EquipmentHealth;
    }
}
