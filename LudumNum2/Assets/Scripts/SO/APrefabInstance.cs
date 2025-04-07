using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APrefabInstance : ScriptableObject
{
    public abstract void SetupInstance(GameObject prefabInstance);
}
