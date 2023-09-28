using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingScript : MonoBehaviour
{
    [SerializeField] private AudioClip healSound;
    public playerLife playerHealth;
    [SerializeField] public int healingValue = 10;


    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = GetComponent<playerLife>();
            playerHealth.addlife(healingValue);
            Debug.Log("potion collide with player");
            SoundManager.instance.PlaySound(healSound);
            Destroy(gameObject);
        }
        
    }

}
