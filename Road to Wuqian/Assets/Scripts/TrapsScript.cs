using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsScript : MonoBehaviour
{
    [SerializeField] private int trapDamage = 10;
    [SerializeField] private AudioClip injureSound;
    [SerializeField] private float slowDrag = 100.0f;
    private float originalDrag = 0.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife p = collision.gameObject.GetComponent<playerLife>();
            if (p != null)
            {
                TrapTrigger(p);
                SlowDownPlayer(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            monster m = collision.gameObject.GetComponent<monster>();
            if (m != null)
            {
                TrapTriggerMonster(m);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RestorePlayerSpeed(collision.gameObject);
        }
    }

    public void TrapTrigger(playerLife p)
    {
        SoundManager.instance.PlaySound(injureSound);
        p.TakeDamage(trapDamage);
    }

    public void TrapTriggerMonster(monster m)
    {
        SoundManager.instance.PlaySound(injureSound);
        m.TakeDamage(trapDamage);
    }
    private void SlowDownPlayer(GameObject player)
    {
        // Check if the player has a PlayerMovement script
        playerMovement ply = player.GetComponent<playerMovement>();

        if (ply != null)
        {
            // Increase the player's linear drag to make them slower
            ply.SetLinearDrag(slowDrag);
        }
    }

    private void RestorePlayerSpeed(GameObject player)
    {
        // Check if the player has a PlayerMovement script
        playerMovement ply = player.GetComponent<playerMovement>();

        if (ply != null)
        {
            // Restore the player's original linear drag
            ply.SetLinearDrag(originalDrag);
        }
    }

}
