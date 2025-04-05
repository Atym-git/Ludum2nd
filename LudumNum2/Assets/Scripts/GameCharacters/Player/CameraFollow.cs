using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 3f;
    [SerializeField] private float _cameraHeight = 1f;
    [SerializeField] private Transform _player;
    private Camera _camera;
    private const float zAxis = -10f;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
        Vector3 newPos = new Vector3(_player.position.x, _player.position.y + _cameraHeight, zAxis);

        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);
    }
}
