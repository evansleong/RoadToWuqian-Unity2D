using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour, IDataPersistance
{
    private int coins = 0;

    private Dictionary<string, bool> collectedCoins = new Dictionary<string, bool>();
    [SerializeField] private Text coinsText;
    [SerializeField] private GameObject portal;

    public void LoadData(GameData data)
    {
        this.coins = data.coinCount;
        foreach (KeyValuePair<string, bool> pair in data.coins)
        {
            if (pair.Value)
            {
                coins ++;
            }
        }

        // Check if the portal should be initially active
        CheckActivatePortal();
    }

    public void SaveData(ref GameData data)
    {
        data.coinCount = this.coins;
    }

    public void CollectCoins(int amount)
    {
        coins += amount;
        Debug.Log(coins);
        UpdateCoinsText();

        // Check if the portal should be activated
        CheckActivatePortal();
    }


    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = " X " + coins;
        }
    }

    private void CheckActivatePortal()
    {
        // Check if the LevelMove_ref script reference is not null and the player has collected 10 or more coins
        if (coins >= 20)
        {
            // Activate the portal (assuming LevelMove_ref has a method or property to activate the portal)
            portal.SetActive(true);
        }
    }
}
