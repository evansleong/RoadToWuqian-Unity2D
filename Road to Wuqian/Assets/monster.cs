using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 100;
    int currentHealth;
    [SerializeField] private float destroyTime = 3;
    [SerializeField] private AudioClip attackSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySound(attackSound);
        currentHealth -= damage;
        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MonsterMovement>().enabled = false;

        Debug.Log("Enemy died");
        anim.SetBool("isDead", true);
        Destroy(gameObject, destroyTime);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
