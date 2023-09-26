using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Attack();
                
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Check if the enemy has a 'monster' script
                monster monsterScript = enemy.GetComponent<monster>();
                if (monsterScript != null)
                {
                    monsterScript.TakeDamage(attackDamage);
                }
            }
            else if (enemy.CompareTag("Boss"))
            {
                // Check if the enemy has a 'bossLife' script
                bossLife bossScript = enemy.GetComponent<bossLife>();
                if (bossScript != null)
                {
                    bossScript.TakeDamage(attackDamage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
