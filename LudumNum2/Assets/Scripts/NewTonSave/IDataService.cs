using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    public bool SaveData<T>(string RelativePath,  T Data, bool Encrypted);

    public T LoadData<T>(string RelativePath, bool Encrypted);
}
