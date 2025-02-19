using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    private Vector3 lastPos;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private UnityEngine.Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        
        animator.SetFloat("magnitude", Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            lastPos = transform.position;
        }

    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TryAgain"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float respawnOffsetX = 1.5f;
        float respawnOffsetY = 1f;
        float moveDirection = rb.velocity.x >= 0 ? -1 : 1;

        // Adjust respawn pos
        transform.position = new Vector3(
            lastPos.x + (respawnOffsetX * moveDirection),
            lastPos.y + respawnOffsetY);

        rb.velocity = Vector2.zero;
    }



}


