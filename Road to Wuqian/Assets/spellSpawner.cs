using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spellPrefabs;
    private GameObject currentSpell;
    [SerializeField] private AudioClip spellSound;
    private bool isSpellActive = false;
    public playerLife playerHealth;
    public Transform target;
    [SerializeField] private AudioClip getHitSound;

    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private LayerMask playerLayer;
    public float range = 2f;

    private bool playerInRange = false;

    private float bossRangeEnterTime = 0f;
    private bool bossInRange = false;
    private float bossActivationDelay = 2f;

    void Start()
    {

    }

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange())
        {
            if (!bossInRange)
            {
                // Player is in range but boss is not, start the delay timer.
                bossRangeEnterTime += Time.deltaTime;

                if (bossRangeEnterTime >= bossActivationDelay)
                {
                    bossInRange = true;
                    spell();
                }
            }
            else
            {
                // Boss is in range, activate the spell immediately.
                spell();
            }
        }
        else
        {
            // Reset the boss-related variables when the player leaves the range.
            bossInRange = false;
            bossRangeEnterTime = 0f;
        }
    }

    void spell()
    {
    // If a spell is already active, don't spawn a new one.
    if (isSpellActive)
    {
        return;
    }

    int ranSpell = Random.Range(0, spellPrefabs.Length);
    int ranSpawPoint = Random.Range(0, spawnPoints.Length);

    currentSpell = Instantiate(spellPrefabs[ranSpell], spawnPoints[ranSpawPoint].position, transform.rotation);
    SoundManager.instance.PlaySound(spellSound);

    // Set the flag to indicate a spell is active.
    isSpellActive = true;

    // Start a coroutine to destroy the spell after 2 seconds.
    StartCoroutine(DestroySpellAfterDelay(4f));
    }

    private IEnumerator DestroySpellAfterDelay(float delay)
    {
    // Wait for the specified delay.
    yield return new WaitForSeconds(delay);

    // Check if there's a current spell (it might have been destroyed by other means).
    if (currentSpell != null)
    {
        Destroy(currentSpell);
    }

    isSpellActive = false;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(circleCollider.bounds.center, circleCollider.radius * range);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerHealth != null)
        {
            playerHealth = target.GetComponent<playerLife>();
            playerHealth.TakeDamage(5);
            playerHealth.PlayHurtAnimation();
            SoundManager.instance.PlaySound(getHitSound);
            Debug.Log("spell attack");
            Destroy(currentSpell);
        }
    }
}