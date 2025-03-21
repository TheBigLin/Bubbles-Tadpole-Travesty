using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RatKing : MonoBehaviour
{
    public int health;
    public int damage;
    public Transform leftWall; 
    public Transform rightWall;
    public Slider healthBar;
    public float jumpForce = 10f;
    public float dashForce = 20f; 
    public float jumpInterval = 2f; 
    public float dashCooldown = 5f;
    public float playerKnockback = 7f;

    private Transform currentWall; 
    private Rigidbody2D rb;
    private Vector2 playerLastKnownPos;
    private bool canDash = true;
    private GameObject player;
    public GameObject Ratking;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
        currentWall = leftWall; 
        player = GameObject.FindGameObjectWithTag("Player"); 

        StartCoroutine(WallJumpRoutine());
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Destroy(Ratking);
            Destroy(healthBar.gameObject);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            playerLastKnownPos = player.transform.position; 
        }
    }

    private IEnumerator WallJumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpInterval);
            JumpToOppositeWall();

            if (canDash)
            {
                StartCoroutine(DashTowardsPlayer());
            }
        }
    }

    private void JumpToOppositeWall()
    {
        Vector2 jumpDirection = (currentWall == leftWall) ? Vector2.right : Vector2.left;
        rb.velocity = new Vector2(jumpDirection.x * jumpForce, jumpForce); 

        
        currentWall = (currentWall == leftWall) ? rightWall : leftWall;
    }

    private IEnumerator DashTowardsPlayer()
    {
        canDash = false;

        yield return new WaitForSeconds(1f); 
        Vector2 dashDirection = (playerLastKnownPos - (Vector2)transform.position).normalized;
        rb.velocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TakeDamage(4);

            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (playerRb.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * playerKnockback, ForceMode2D.Impulse);
            }
        }
    }
}





