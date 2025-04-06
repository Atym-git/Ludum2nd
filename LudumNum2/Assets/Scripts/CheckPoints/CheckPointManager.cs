using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public static class CheckPointManager
{
    private static List<Transform> spawnPoints = new List<Transform>();
    
    private static IDataService DataService = new JsonDataService();
    private static bool EncryptionEnabled;

    public static void SerializeJson()
    {
        if (DataService.SaveData("/player-stats.json", spawnPoints, EncryptionEnabled))
        {
            try
            {
                spawnPoints = DataService.LoadData<List<Transform>>("/player-stats.json", EncryptionEnabled);
            }
            catch (Exception e)
            {
                Debug.LogError($"Could not read file due to {e.Message} {e.StackTrace}");
            }
        }
        else
        {
            Debug.LogError("Could not save file!");
        }
    }

    public static void AddCheckPoint(Transform playerSpawnPoint)
    {
        if (!spawnPoints.Contains(playerSpawnPoint))
        {
            spawnPoints.Add(playerSpawnPoint);
            SerializeJson();
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
    public static List<Transform> GetCurrCheckpoints()
    {
        return spawnPoints;
    }
    
}
