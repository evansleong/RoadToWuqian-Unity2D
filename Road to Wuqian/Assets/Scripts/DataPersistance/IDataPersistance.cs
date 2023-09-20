using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void LoadData(GameData data); //when load only read
    void SaveData(ref GameData data); // when save, allow implemnting script to modify data, thats why use ref 
}
