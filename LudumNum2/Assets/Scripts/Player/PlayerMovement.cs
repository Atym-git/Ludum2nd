using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _jumpKey;

    private Rigidbody2D _rb;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius = 0.5f;

    private InputAction _movement;
    private PlayerInput _playerActions;

    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerActions = new PlayerInput();
        Bind();
    }

    private void Bind()
    {
        _movement = _playerActions.Player.Move;
        _movement.Enable();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, groundLayerMask);
        //Debug.Log($"_isGround: {_isGrounded}");
    }


    private void FixedUpdate()
    {
        float horMovement = _movement.ReadValue<float>();
        //Vector2 _movement2d = _movement.ReadValue<Vector2>().normalized;
        _rb.velocity = new Vector2(horMovement, 0) * _moveSpeed;
        //_rb.velocity = new Vector2(_movement2d.x, _movement2d.y) * _moveSpeed;
    }
}
