using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour/*, IDataPersistance*/
{
    public int maxHealth = 10;
    public int health;
    public HealthBar healthBar;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject deathscene;
    private bool hasDeathSound = false;
    private bool isDead = false;

    private Rigidbody2D rb;
    private Animator anim;
    //private Checkpoint ckptMng;
    //private Vector3 lastCheckPointPos;

    //[Header("Respawn Point")]
    //[SerializeField] private Transform rspwnPt;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //ckptMng = FindObjectOfType<Checkpoint>();
        //transform.position = ckptMng.getLastCkptPos();
    }

    private void Update()
    {
        if (health != 0)
        {
            isDead = false;
        }
        if (health <= 0 && !hasDeathSound)
        {
            Die();
            if(isDead == true)
            {
                StartCoroutine(Deadscene());
            }

        }
        //else
        //{
        //    deathscene.SetActive(false);
        //}
    }

    public void PlayHurtAnimation()
    {
        anim.SetTrigger("hurt");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");

        healthBar.SetHealth(health);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Traps"))
    //    {
    //        Die();
    //    }
    //    if (collision.gameObject.CompareTag("Checkpoint"))
    //    {
    //        lastCheckPointPos = other.transform.position;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Checkpoint"))
    //    {
    //        lastCheckPointPos = other.transform.position;
    //    }
    //}

    private void Die()
    {
        anim.SetTrigger("death");
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        //Destroy(gameObject, 10);
        health = 0;
        healthBar.SetHealth(health);
        if (!hasDeathSound)
        {
            SoundManager.instance.PlaySound(deathSound);
            hasDeathSound = true;
        }
        StartCoroutine(RestartLevel());

    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void LoadData(GameData data)
    //{
    //    this.transform.position = data.playerPos;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.playerPos = this.transform.position;
    //}

    IEnumerator Deadscene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
