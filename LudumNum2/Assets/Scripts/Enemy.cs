using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 0.05f;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.GetComponent<PlayerInput>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _followSpeed);
        }
    }
}
