using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius = 0.05f;

    private InputAction _movement;
    private PlayerInput _playerActions;

    private bool _isGrounded = false;
    private bool _srFlipX = false;

    private const string _animIdleName = "IsIdle";
    private const string _animWalkingName = "IsWalking";

    private bool _animIdle;
    private bool _animWalking;

    [SerializeField] private AudioClip _walkingAudioClip;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerActions = new PlayerInput();
        _playerActions.Enable();
        Bind();
    }

    private void Bind()
    {
        _playerActions.Player.Jump.performed += Jump;
        _movement = _playerActions.Player.Move;
        _movement.Enable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
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
        //_srFlipX = horMovement < 0;
        if (horMovement < 0)
        {
            _srFlipX = true;
        }
        else if (horMovement > 0)
        {
            _srFlipX = false;
        }
        _animIdle = horMovement == 0;
        _animWalking = horMovement != 0;
        _animator.SetBool(_animIdleName, _animIdle);
        _animator.SetBool(_animWalkingName, _animWalking);
        SoundFXManager.SFXinstance.PlaySoundFXClip(_walkingAudioClip, transform, 1f);
        _rb.velocity = new Vector2(horMovement * _moveSpeed, _rb.velocity.y);
        _sr.flipX = _srFlipX;
    }

    private void Update()
    {
        CheckGround();
    }

    private void OnDestroy()
    {
        _playerActions.Disable();
        _playerActions.Player.Jump.performed -= Jump;
    }
}
