using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public HealthBar healthBar;
    [SerializeField] private AudioClip deathSound;
    private bool hasDeathSound = false;

    private Rigidbody2D rb;
    private Animator anim;
    private Checkpoint ckptMng;
    private Vector3 lastCheckPointPos;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ckptMng = FindObjectOfType<Checkpoint>();
    }

    private void Update()
    {
        if (health <= 0 && !hasDeathSound)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");

        healthBar.SetHealth(health);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckPointPos = other.transform.position;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //Destroy(gameObject, 10);
        health = 0;
        healthBar.SetHealth(health);
        if (!hasDeathSound)
        {
            SoundManager.instance.PlaySound(deathSound);
            hasDeathSound = true;
        }
        anim.SetTrigger("death");
        transform.position = ckptMng.getLastCkptPos();
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
