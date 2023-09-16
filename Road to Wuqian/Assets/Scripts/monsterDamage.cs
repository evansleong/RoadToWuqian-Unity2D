using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDamage : MonoBehaviour
{
    public int damage;
    public playerLife playerHealth;
    public playerMovement playMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playMovement.KBCounter = playMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playMovement.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
