using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData
{
    void LoadData(GameData data); //reads data
    void SaveData(ref GameData data); //ref - pass by reference in order for implementing script to modify data
}
