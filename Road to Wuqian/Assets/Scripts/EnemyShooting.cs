using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {


        //represent distance between enemy and player
        float distance = Vector2.Distance(transform.position, player.transform.position);
        //get distance at all times
        Debug.Log(distance);

        if (distance <= 5)
        {
            timer += Time.deltaTime;

                if (timer > 2)
                {
                timer = 0;
                shoot();
                }
        }
    }

    void shoot()
    {
        Instantiate(projectile, projectilePos.position,Quaternion.identity);
    }

}
