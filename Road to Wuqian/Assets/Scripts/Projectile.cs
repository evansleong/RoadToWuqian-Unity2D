using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;
    //public Animator anim;

    public float projectileLife;
    public float projectileCount;

    public playerMovement plyMovement;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        projectileCount = projectileLife;
        plyMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        facingRight = plyMovement.facingRight;
        if(!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (facingRight)
        {
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
        }
        else
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //anim.SetTrigger("explode");
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}