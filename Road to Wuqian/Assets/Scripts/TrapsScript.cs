using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsScript : MonoBehaviour
{
    [SerializeField] private int trapDamage = 10;
    [SerializeField] private AudioClip injureSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife p = collision.gameObject.GetComponent<playerLife>();
            if (p != null)
            {
                SoundManager.instance.PlaySound(injureSound);
                p.TakeDamage(trapDamage);
            }
        }
    }
}
