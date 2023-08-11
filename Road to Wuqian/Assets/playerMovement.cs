using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool midJump = false;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    private enum MovementState { idle, running, jumping }
    private MovementState state = MovementState.jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (!midJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Change Vector3 to Vector2
            midJump = true;
            anim.SetBool("Jumping", true);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            midJump = false;
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
