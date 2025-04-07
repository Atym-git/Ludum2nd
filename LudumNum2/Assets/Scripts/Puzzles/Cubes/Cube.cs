using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _cubeIndex;

    private bool _isCursorOnCube = false;

    private CubesPuzzle _cubesPuzzle;

    private float _xAxisRot = 90;

    public void SetupCube(int index)
    {
        _cubeIndex = index;
        _cubesPuzzle = transform.parent.GetComponent<CubesPuzzle>();
    }

    private void OnMouseEnter()
    {
        _isCursorOnCube = true;
        if (Input.GetMouseButtonDown(0)) 
        {
            transform.rotation = new Quaternion(_xAxisRot, 0, 0, 0);
            _cubesPuzzle.RotateCube(_cubeIndex);
        }
    }
    private void OnMouseExit()
    {
        _isCursorOnCube = false;
    }
}
