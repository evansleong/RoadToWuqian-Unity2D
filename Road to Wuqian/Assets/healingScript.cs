using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingScript : MonoBehaviour
{
    [SerializeField] private AudioClip healSound;
    public playerLife playerHealth;
    [SerializeField] public int healingValue = 10;
    private Collider2D itemCollider;
    private Renderer itemRenderer;


    void Start()
    {
        // Get references to the Collider2D and Renderer components
        itemCollider = GetComponent<Collider2D>();
        itemRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife playerHealth = collision.gameObject.GetComponent<playerLife>();
            //playerHealth = GetComponent<playerLife>();
            playerHealth.addlife(healingValue);
            Debug.Log("potion collide with player");
            SoundManager.instance.PlaySound(healSound);
            itemCollider.enabled = false;
            itemRenderer.enabled = false;
        }
        
    }

}
