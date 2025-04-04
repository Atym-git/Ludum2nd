using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.05f;
    private Rigidbody2D _rb2D;

    private float _maxXPosition;
    private float _minXPosition;

    private int _direction = 1;

    private float _minTimeToTurn = 7.5f;
    private float _maxTimeToTurn = 12.5f;

    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _playerLayerMask;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomTurn());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_groundLayerMask, collision.gameObject))
        {
            //(Scale - 1) / 2 = delta for max & min values
            _maxXPosition = collision.transform.position.x + ((collision.transform.lossyScale.x - 1) / 2);
            _minXPosition = collision.transform.position.x - ((collision.transform.lossyScale.x - 1) / 2);
        }
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator RandomTurn()
    {
        while (true)
        {
            float timeToTurn = Random.Range(_minTimeToTurn, _maxTimeToTurn);
            yield return new WaitForSeconds(timeToTurn);
            _direction *= -1;
        }
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        if (transform.position.x >= _maxXPosition || transform.position.x <= _minXPosition)
        {
            _direction *= -1;
        }
        _rb2D.velocity = new Vector2(_moveSpeed * _direction, _rb2D.velocity.y);
    }
}
