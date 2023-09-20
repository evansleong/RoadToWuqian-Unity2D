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
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coins+=2;
            coinsText.text = " X " + coins;
        }
    }
}
