using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public int damage;
    public playerLife playerHealth;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4)
        {
            timer = 0;
            gameObject.SetActive(false);
            Debug.Log("Projectile Despawned");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<playerLife>();
            playerHealth.TakeDamage(damage);
            Debug.Log("player health -2");
            gameObject.SetActive(false);
            Debug.Log("Projectile despawned");
        }
    }

    public void AimPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {      //set bullet to aim player
            Vector2 direction = player.transform.position - transform.position;
            Debug.Log(direction);
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

            //let bullet rotate
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90); 
        }
    }

}
