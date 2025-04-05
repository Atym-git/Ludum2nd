using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckPointManager
{
    private static List<Transform> spawnPoints = new List<Transform>();

    public static void AddCheckPoint(Transform playerSpawnPoint)
    {
        if (!spawnPoints.Contains(playerSpawnPoint))
        {
            spawnPoints.Add(playerSpawnPoint);
        }
    }

    public static Vector3 BackToCheckPoint()
    {
        if (spawnPoints.Count > 0)
        {
            return spawnPoints[spawnPoints.Count - 1].position;
        }
        return Vector3.zero;
    }
}
