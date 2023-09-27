using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemy : MonoBehaviour
{
    [SerializeField] private float sAttackCooldown;
    public float range = 2f;
    [SerializeField] private LayerMask playerLayer;
    private CircleCollider2D circleCollider;
    [SerializeField] private AudioClip castingSound;
    private float sCooldownTimer = Mathf.Infinity;

    public Animator anim;
    private enemyPatrol enemyPatrol;
    private Transform player;
    private bool isDelaying = false;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object.
    }

    private void Update()
    {
        sCooldownTimer += Time.deltaTime;

        if (PlayerInRange())
        {
            if (sCooldownTimer >= sAttackCooldown)
            {
                if (!isDelaying)
                {
                    StartCoroutine(DelayBossFacingPlayer(1.5f)); // Delay for one second.
                }
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInRange();
        }
    }

    private IEnumerator DelayBossFacingPlayer(float delay)
    {
        isDelaying = true;
        yield return new WaitForSeconds(delay);

        anim.SetTrigger("rangeAttack");
        SoundManager.instance.PlaySound(castingSound);

        // Face the player when casting the spell.
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction.x > 0)
        {
            // Face right.
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            // Face left.
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        isDelaying = false;
        sCooldownTimer = 0f; // Reset the cooldown timer.
    }

    private bool PlayerInRange()
    {
        // Use CircleCast to check for a collider within the circle's bounds.
        RaycastHit2D hit = Physics2D.CircleCast(
            circleCollider.bounds.center,      // Center of the circle.
            circleCollider.radius * range,     // Radius of the circle multiplied by range.
            Vector2.left,                      // Direction (left in this example).
            0,                                 // No rotation.
            playerLayer                         // Layer mask for the player.
        );

        if (hit.collider != null)
        {
            return true;
        }

        // Player not found in range.
        return false;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.black;
    //     Gizmos.DrawWireSphere(circleCollider.bounds.center, circleCollider.radius * range);
    // }
}
