using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip kbSound;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    public bool facingRight;

    private bool isCrouching = false;
    private bool hasKBsound = false;
    private bool hasWalkSound = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    private enum MovementState { idle, running, jumping }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            hasKBsound = false;
        }
        else
        {
            if (KBCounter > 0 && !hasKBsound)
            {
                if (KnockFromRight == true)
                {
                    SoundManager.instance.PlaySound(kbSound);
                    rb.velocity = new Vector2(-KBForce, KBForce);
                }
                if (KnockFromRight == false)
                {
                    SoundManager.instance.PlaySound(kbSound);
                    rb.velocity = new Vector2(KBForce, KBForce);
                }
            }

            KBCounter -= Time.deltaTime;
            hasKBsound = true;
        }
        //dirX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isCrouching = false;
            anim.SetBool("crouch", isCrouching);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = !isCrouching;
            anim.SetBool("crouch", isCrouching);  // Set the "Crouch" parameter in the Animator
        }
 

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if(dirX !=0 && !hasWalkSound)
        {
            SoundManager.instance.PlaySound(walkSound);
            hasWalkSound = true;
        }

        if (dirX > 0f)
        {
            facingRight = true;
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            facingRight = false;
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            //sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            hasWalkSound = false;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
