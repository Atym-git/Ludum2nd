using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{

    private void SaveCheckpoints()
    {
        List<Transform> checkpoints = CheckPointManager.GetCurrCheckpoints();
        Vector3 lastCheckPointPos = checkpoints[checkpoints.Count - 1].position;
        string transformIntoString = $"{lastCheckPointPos.x};{lastCheckPointPos.y};{lastCheckPointPos.z}";

        //string[] values = lines[i].Split(';');
        PlayerPrefs.SetString("", transformIntoString);
    }
}
