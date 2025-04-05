using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform _playerSpawnPoint;

    private void Start()
    {
        _playerSpawnPoint = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            CheckPointManager.AddCheckPoint(_playerSpawnPoint);
        }
    }
}
