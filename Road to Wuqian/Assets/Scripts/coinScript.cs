using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int coinValue = 2;

    [SerializeField] private string id;

    private bool isCollected = false;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemCollector pc = collision.gameObject.GetComponent<itemCollector>();

            if (pc != null)
            {
                pc.CollectCoins(coinValue);
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }

    public void LoadData(GameData data)
    {
        data.coins.TryGetValue(id, out isCollected);
        if (isCollected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.coins.ContainsKey(id))
        {
            data.coins.Remove(id);
        }
        data.coins.Add(id, isCollected);
    }

}
