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
                TrapTrigger(p);
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
}
