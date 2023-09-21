using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    [SerializeField] private int coinValue = 2;

    [SerializeField] private string id;

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
                Destroy(gameObject);
            }
        }
    }

}
