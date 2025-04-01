using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    private Vector3 lastPos;
    public bool canMove = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private UnityEngine.Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource runningSound;
    [SerializeField] private DialogueRunner dialogueRunner;

    private void Start()
    {

        dialogueRunner.onDialogueComplete.AddListener(EnableMovement);
    }

    void Update()
    {
        if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetFloat("magnitude", 0);
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpSound.Play();
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        HandleRunningSound();
        Flip();

        animator.SetFloat("magnitude", Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            lastPos = transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
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

    private void HandleRunningSound()
    {
        if (Mathf.Abs(horizontal) > 0 && IsGrounded())
        {
            if (!runningSound.isPlaying)
            {
                runningSound.Play();
            }
        }
        else
        {
            if (runningSound.isPlaying)
            {
                runningSound.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TryAgain"))
        {
            Respawn();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("HeadCollider") && rb.velocity.y < 0)
        {

            Destroy(other.gameObject);
        }
    }



    void Respawn()
    {
        float respawnOffsetX = 1.5f;
        float respawnOffsetY = 1f;
        float moveDirection = rb.velocity.x >= 0 ? -1 : 1;

        transform.position = new Vector3(
            lastPos.x + (respawnOffsetX * moveDirection),
            lastPos.y + respawnOffsetY);

        rb.velocity = Vector2.zero;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }



}