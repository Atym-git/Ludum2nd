using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInTrigger : MonoBehaviour
{
    private float _stopChaseTime = 3f;

    private EnemyMovement _enemy;

    private int _lastEnterIndex;
    private void Start()
    {
        _enemy = transform.parent.GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _lastEnterIndex++;
            int direction = Mathf.Clamp(Mathf.RoundToInt(collision.transform.position.x - transform.parent.transform.position.x), -1, 1);
            //Debug.Log("Difference in positions: " + Mathf.Clamp(Mathf.RoundToInt(collision.transform.position.x - transform.parent.transform.position.x), -1, 1));
            //Debug.Log($"Chase direction: {direction}");
            _enemy.BeginPlayerChase(direction);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            StartCoroutine(StopChasing());
        }
    }
    private IEnumerator StopChasing()
    {
        yield return new WaitForSeconds(_stopChaseTime);
        _lastEnterIndex--;
        if (_lastEnterIndex == 0)
        {
            _enemy.EndPlayerChase();
        }
    }
}
