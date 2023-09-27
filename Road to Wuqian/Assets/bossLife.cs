using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossLife : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] GameObject gameObject;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] private float destroyTime = 3;
    [SerializeField] private AudioClip attackSound;
    public GameObject boss;
    public int currentHealth;
    public HealthBar healthBar;
    public int sceneBuildIndex;

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
            //SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    void Die()
    {
        Debug.Log("Boss died");
        anim.SetBool("isDead", true);
        Destroy(gameObject, destroyTime);
        StartCoroutine(wait());
        victoryScene();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
        //SceneManager.LoadScene("VictoryScene");
    }

    IEnumerator wait()
    {  
        Debug.Log("boss killed");
        yield return new WaitForSeconds(3);
    }

    public void victoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }

}