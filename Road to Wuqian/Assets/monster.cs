using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 100;
    int currentHealth;
    //public HealthBar healthBar;
    [SerializeField] private float destroyTime = 3;
    [SerializeField] private AudioClip attackSound;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySound(attackSound);
        currentHealth -= damage;
        anim.SetTrigger("hurt");
        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MonsterMovement>().enabled = false;

        //healthBar.SetHealth(currentHealth);
        Debug.Log("Enemy died");
        anim.SetBool("isDead", true);
        Destroy(gameObject, destroyTime);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }

}
