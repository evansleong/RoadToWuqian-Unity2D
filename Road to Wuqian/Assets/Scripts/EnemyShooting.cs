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
        Debug.Log(distance);

        if (distance <= 5)
        {
            timer += Time.deltaTime;

                if (timer > 2)
                {
                timer = 0;
                shoot();
                Debug.Log("Projectile shot");
                }
        }
    }

    void shoot()
    {
        //Instantiate(projectile, projectilePos.position,Quaternion.identity);

        //get bullet from object pool
        GameObject bullet = BulletPool.bullet.GetBulletFromPool();
        Debug.Log("projectile spawned");

        //if bullet is not null, set position and enable
        if(bullet != null)
        {
            bullet.transform.position = projectilePos.position;
            bullet.SetActive(true);
        }
    }

}
