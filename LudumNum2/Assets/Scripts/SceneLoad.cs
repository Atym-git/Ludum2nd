using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void sceneLoad(int NumbScene)
    { 
        SceneManager.LoadScene(NumbScene);
    }
}
