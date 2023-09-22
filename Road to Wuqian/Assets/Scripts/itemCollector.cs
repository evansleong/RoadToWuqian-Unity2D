using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour, IDataPersistance
{
    private int coins = 0;

    private Dictionary<string, bool> collectedCoins = new Dictionary<string, bool>();
    [SerializeField] private Text coinsText;

    public void LoadData(GameData data)
    {
        this.coins = data.coinCount;
        foreach(KeyValuePair<string,bool>pair in data.coins)
        {
            if (pair.Value)
            {
                coins+=2;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.coinCount = this.coins;
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
