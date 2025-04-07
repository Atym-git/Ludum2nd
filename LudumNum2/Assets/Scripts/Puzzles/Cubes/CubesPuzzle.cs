using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPuzzle : MonoBehaviour
{
    [SerializeField] private int[] _cubesCorrectRot;
    private int[] _cubesCurrRot = { 0, 0, 0};

    [SerializeField] private int _firstCubeCorrectRot = 3;
    [SerializeField] private int _secondCubeCorrectRot = 2;
    [SerializeField] private int _thirdCubeCorrectRot = 1;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Cube>().SetupCube(i);
        }
    }
    public void RotateCube(int cubeIndex)
    {
        if (_cubesCurrRot[cubeIndex] < 3)
        {
            _cubesCurrRot[cubeIndex]++;
        }
        else
        {
            _cubesCurrRot[cubeIndex] = 0;
        }
        IsPuzzleSolved();
    }
    private bool IsPuzzleSolved()
    {
        for (int i = 0; i < _cubesCurrRot.Length; i++)
        {
            if (_cubesCurrRot[i] != _cubesCorrectRot[i])
            {
                return false;
            }
        }
        return true;
    }
}
