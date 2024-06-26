using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX;
    private SpriteRenderer sr;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed=7f;
    [SerializeField] private float jumpForce=14f;
    private enum moveState {idle,running,jump,fall}

    [SerializeField] private AudioSource JumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
        UpdateAnimation();
    }
    private void UpdateAnimation(){
        moveState state;
        if(dirX > 0f)
        {
            state = moveState.running;
            sr.flipX=false;
        }
        else if(dirX < 0f)
        {
            state = moveState.running;
            sr.flipX=true;
        }
        else
        {
            state = moveState.idle;
        }
        if(rb.velocity.y>.1f)
        {
            state = moveState.jump;
        }
        else if(rb.velocity.y<-.1f)
        {
            state = moveState.fall;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
