using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, playerTransform.position) > 10)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                sprite.flipX = true;
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                sprite.flipX = false;
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                sprite.flipX = false;
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                sprite.flipX = true;
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    patrolDestination = 0;
                }
            }
        }

        //if(patrolDestination == 0)
        //{
        //    sprite.flipX = false;
        //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
        //    if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
        //    {
        //        patrolDestination = 1;
        //    }
        //}

        //if (patrolDestination == 1)
        //{
        //    sprite.flipX = true;
        //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
        //    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
        //    {
        //        patrolDestination = 0;
        //    }
        //}
    }
}





