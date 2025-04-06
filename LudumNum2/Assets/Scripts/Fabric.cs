using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fabric : MonoBehaviour
{
    private Object enemyPrefab;
    private Object itemPrefab;

    private Transform[] enemyTransforms;
    private Transform[] itemTransforms;

    private EnemySO[] enemySOs;
    private ItemSO[] itemSOs;

    private void Start()
    {
        LoadResources();
    }

    private void InstantiateSOs(APrefabInstance[] SOs, GameObject prefab, Transform[] transforms, Sprite sprite, float damage,
        float health, GameObject affectedGameObject)
    {   
        for (int i = 0; i < SOs.Length; i++)
        {
            GameObject instance = Instantiate(prefab, transforms[i]);
            SOs[i].SetupInstance(instance);
        }
    }

    private void LoadResources()
    {
        enemySOs = Resources.LoadAll("SO/EnemySO", typeof (EnemySO))
            .Cast<EnemySO>()
            .ToArray();
        //Assets/Resources/SO/EnemySO
        itemSOs = Resources.LoadAll("SO/ItemSO", typeof(ItemSO))
            .Cast<ItemSO>()
            .ToArray();
        //Assets/Resources/SO/ItemSO
    }
}
