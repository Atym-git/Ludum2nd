using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fabric : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Transform[] enemyTransforms;
    [SerializeField] private Transform[] itemTransforms;

    private EnemySO[] enemySOs;
    private ItemSO[] itemSOs;

    private void Start()
    {
        LoadResources();
        for (int i = 0; i < enemyTransforms.Length; i++)
        {
            if (i == enemySOs.Length)
            {
                break;
            }
            InstantiateSO(enemySOs[i], enemyPrefab, enemyTransforms[i]);
        }
        for (int i = 0; i < itemTransforms.Length; i++)
        {
            if (i == itemSOs.Length)
            {
                break;
            }
            InstantiateSO(itemSOs[i], itemPrefab, itemTransforms[i]);
        }
    }

    private void InstantiateSO(APrefabInstance SOs, GameObject prefab, Transform transforms)
    {
        GameObject instance = Instantiate(prefab, transforms);
        SOs.SetupInstance(instance);
    }

    private void LoadResources()
    {
        enemySOs = Resources.LoadAll("SO/EnemySO", typeof (EnemySO))
            .Cast<EnemySO>()
            .ToArray();
        itemSOs = Resources.LoadAll("SO/ItemSO", typeof(ItemSO))
            .Cast<ItemSO>()
            .ToArray();
    }
}
