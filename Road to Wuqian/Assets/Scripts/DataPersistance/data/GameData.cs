using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Dictionary<string,bool> coins;
    public Vector3 playerPos;
    public int coinCount;
    //public Dictionary<string, bool> 

    //when start new game, initialize this value
    public GameData()
    {
        coins = new Dictionary<string, bool>();
        playerPos = Vector3.zero;
        coinCount = 0;
    }
}