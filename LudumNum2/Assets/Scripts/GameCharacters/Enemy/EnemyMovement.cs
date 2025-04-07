using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 3f;
    private Rigidbody2D _rb2D;

    private float _maxXPosition;
    private float _minXPosition;

    private int _direction = 1;

    private float _minTimeToTurn = 7.5f;
    private float _maxTimeToTurn = 12.5f;

    private SpriteRenderer _sr;
    private bool _srFlipX = false;
    private bool _isChasing = false;

    [SerializeField] private LayerMask _groundLayerMask;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
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
    }

    private IEnumerator RandomTurn()
    {
        while (!_isChasing)
        {
            float timeToTurn = Random.Range(_minTimeToTurn, _maxTimeToTurn);
            yield return new WaitForSeconds(timeToTurn);
            _direction *= -1;
            _srFlipX = !_srFlipX;
            Debug.Log("Random Turn");
        }
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }
    public void BeginPlayerChase(int direction)
    {
        _isChasing = true;
        _direction = direction;
    }
    public void EndPlayerChase()
    {
        _isChasing = false;
        _direction *= -1;
    }
    private void EnemyMove()
    {
        if (transform.position.x >= _maxXPosition || transform.position.x <= _minXPosition)
        {
            _direction *= -1;
            _srFlipX = !_srFlipX;
        }
        _rb2D.velocity = new Vector2(MoveSpeed * _direction, _rb2D.velocity.y);
        _sr.flipX = _srFlipX;
    }
}
