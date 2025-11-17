using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 12f;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;

    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        HandleFlip();
        HandleRun();
        HandleJump();
    }

    private void HandleRun()
    {
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("run", horizontalInput != 0);

        if (wallJumpCooldown < 0.2f)
        {
            wallJumpCooldown += Time.deltaTime;
            return;
        }

        if (OnWallOnly())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }

    private void HandleFlip()
    {
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleJump()
    {
        if (!Input.GetKey(KeyCode.Space)) return;

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (OnWallOnly())
        {
            body.gravityScale = 7;
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10f, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), 1, 1);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3f, 6f);
            }

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private bool onWall()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
    }

    private bool OnWallOnly()
    {
        return onWall() && !isGrounded();
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
