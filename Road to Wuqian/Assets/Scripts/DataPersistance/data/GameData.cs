using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int coins;
    public Vector3 playerPos;
    //public Dictionary<string, bool> 

    //when start new game, initialize this value
    public GameData()
    {
        this.coins = 0;
        playerPos = Vector3.zero;
    }
}