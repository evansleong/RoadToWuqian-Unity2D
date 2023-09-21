using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour, IDataPersistance
{
    private int coins = 0;

    [SerializeField] private Text coinsText;

    public void LoadData(GameData data)
    {
        this.coins = data.coins;
        foreach(KeyValuePair<string,bool>pair in data.coins)
        {
            if (pair.Value)
            {
                coins++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
    }

    public void CollectCoins(int amount)
    {
        coins += amount;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = " X " + coins;
        }
    }
}
