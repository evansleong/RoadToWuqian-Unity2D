using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLife : MonoBehaviour
{
    [SerializeField] public Animator anim;

    [SerializeField] public int maxHealth = 100;
    [SerializeField] private float destroyTime = 3;
    [SerializeField] private AudioClip attackSound;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("damaging boss");
        SoundManager.instance.PlaySound(attackSound);
        currentHealth -= damage;
        anim.SetTrigger("hurt");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss died");
        anim.SetBool("isDead", true);
        Destroy(gameObject, destroyTime);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }

}