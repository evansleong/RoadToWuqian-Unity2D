using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int coins;

    //when start new game, initialize this value
    public GameData()
    {
        this.coins = 0;
    }
}