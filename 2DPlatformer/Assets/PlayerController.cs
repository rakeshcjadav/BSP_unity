using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpVelcity;

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool playerDir = false;
    private float previousWalkDir = 1.0f;

    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Walk(InputAction.CallbackContext context)
    {
        float walkingDirection = context.ReadValue<float>();
        Vector2 velocity = rb2D.velocity;
        rb2D.velocity = new Vector2(walkingDirection * WalkSpeed, velocity.y);
        previousWalkDir = (walkingDirection != 0.0f) ? walkingDirection : previousWalkDir;
        animator.SetFloat("Speed", Mathf.Abs(WalkSpeed));
    }

    public void Jump(InputAction.CallbackContext context)
    {
        RaycastHit2D hits = Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), ~(1 << 10));
        if(hits.collider && (hits.collider.gameObject.tag == "BackGround" || hits.collider.gameObject.tag == "ForeGround"))
        {
            Vector2 velocity = rb2D.velocity;
            rb2D.velocity = new Vector2(velocity.x, JumpVelcity);
            animator.SetBool("Jumping", true);
        }
    }

    public void Update()
    {
        
        if(Mathf.Abs(rb2D.velocity.x) < 0.01f)
        {
            animator.SetFloat("Speed", Mathf.Abs(0.0f));
        }
        if (rb2D.velocity.y < 0.0f && Mathf.Abs(rb2D.velocity.y) > 0.0f)
        {
            animator.SetBool("Landing", true);
            animator.SetBool("Jumping", false);
        }
        if (Mathf.Abs(rb2D.velocity.y) < 0.01f)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Landing", false);
        }
        spriteRenderer.flipX = (previousWalkDir < 0.0f);

        //animator.SetFloat("VerticalVelocity", rb2D.velocity.y);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z));
    }
}
