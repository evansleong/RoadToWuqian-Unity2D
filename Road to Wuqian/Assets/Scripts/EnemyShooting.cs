using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    private float timer;
    private GameObject player;
    private BulletPool bulletPool;
    private EnemyProjectileScript ep;
    public Animator anim;
    [SerializeField] private AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletPool = FindObjectOfType<BulletPool>();
        if (bulletPool == null)
        {
            Debug.LogError("BulletPool not found.");
        }

    }

    // Update is called once per frame
    void Update()
    {


        //represent distance between enemy and player
        float distance = Vector2.Distance(transform.position, player.transform.position);
        //get enemy to face player;
        Vector2 direction = player.transform.position - transform.position;
        //if player on left rotate to left else right
        if(player.transform.position.x - transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //get distance at all times
        //Debug.Log(distance);

        if (distance <= 5)
        {
            timer += Time.deltaTime;
            //Debug.Log("time check" + timer);
                if (timer > 2)
                {
                timer = 0;
                shoot();
            }

            Debug.Log("attack false");
            anim.SetBool("isAttack", false);
        }
    }

    void shoot()
    {
        //Instantiate(projectile, projectilePos.position,Quaternion.identity);

        //get bullet from object pool
        Debug.Log("attack true");
        anim.SetBool("isAttack", true);
        //StartCoroutine();
        SoundManager.instance.PlaySound(shootSound);
        GameObject bullet = BulletPool.bullet.GetBulletFromPool();
       

        //if bullet is not null, set position and enable
        if(bullet != null)
        {
            Debug.Log("projectile spawned");
            bullet.transform.position = projectilePos.position;
            bullet.SetActive(true);
            ep = bullet.GetComponent<EnemyProjectileScript>();
            ep.AimPlayer();
        }
    }

}
