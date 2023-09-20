using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    public playerLife playerHealth;

    private enemyPatrol enemyPatrol;

    public Transform target;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        
        if(PlayerInRange())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangeAttack");
            }         
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInRange();
        }
    }

    private bool PlayerInRange()
    {
        // RaycastHit2D hit = Physics2D.CircleCast(circleCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        // new Vector3(circleCollider.bounds.size.x * range, circleCollider.bounds.size.y, circleCollider.bounds.size.z),
        // 0, Vector2.left, 0, playerLayer);

            RaycastHit2D hit = Physics2D.CircleCast(
            circleCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,      // Center of the circle.
            circleCollider.radius * range,     // Radius of the circle multiplied by range.
            Vector2.left,                      // Direction (left in this example).
            0,                                 // No rotation.
            playerLayer                         // Layer mask for the player.
        );

        if(hit.collider != null)
        {
            playerHealth  = hit.transform.GetComponent<playerLife>();
        }

        return hit.collider != null;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            playerHealth  = hit.transform.GetComponent<playerLife>();
        }

        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth = gameObject.GetComponent<playerLife>();
            playerHealth.TakeDamage(damage);
        }
        if(PlayerInRange())
        {
            playerHealth = gameObject.GetComponent<playerLife>();
            playerHealth.TakeDamage(5);
        }        
    }
}
