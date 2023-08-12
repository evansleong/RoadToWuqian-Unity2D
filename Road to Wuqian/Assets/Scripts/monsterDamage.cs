using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDamage : MonoBehaviour
{
    public int damage;
    public playerLife playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
