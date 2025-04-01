using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToadKing : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 0f;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;
    public float playerKnockback = 7f;

    public Slider healthBar;
    public GameObject Toadking;
    public AudioSource bossMusic; // Boss music
    public AudioSource backgroundMusic; // Background music

    public Transform player;
    public float jumpForce = 10f;
    public float jumpCooldown = 2f;
    public float jumpTriggerRange = 5f;

    private Vector2 lastKnownLocation;
    private float jumpCooldownTimer = 0f;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool hasStartedMusic = false; 
    public bool isDead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
            healthBar.gameObject.SetActive(false); 
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (player != null && isGrounded)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            
            if (distanceToPlayer <= jumpTriggerRange && !hasStartedMusic)
            {
                if (healthBar != null)
                {
                    healthBar.gameObject.SetActive(true);
                }

                
                if (backgroundMusic != null && backgroundMusic.isPlaying)
                {
                    backgroundMusic.Stop();
                }

                if (bossMusic != null && !bossMusic.isPlaying)
                {
                    bossMusic.Play();
                }

                hasStartedMusic = true;
            }

            if (distanceToPlayer <= jumpTriggerRange && jumpCooldownTimer <= 0f)
            {
                lastKnownLocation = player.position;
                JumpToPlayerLastLocation();
                jumpCooldownTimer = jumpCooldown;
            }
            else
            {
                jumpCooldownTimer -= Time.deltaTime;
            }
        }

        if (timeBtwDamage > 2)
        {
            timeBtwDamage -= Time.deltaTime;
        }
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
            if (bossMusic != null && bossMusic.isPlaying)
            {
                bossMusic.Stop(); 
            }

           
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }

            Destroy(Toadking);
            Destroy(healthBar.gameObject);
        }
    }

    private void JumpToPlayerLastLocation()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2((lastKnownLocation.x - rb.position.x), 0).normalized * jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TakeDamage(2);

            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (playerRb.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * playerKnockback, ForceMode2D.Impulse);
            }
        }
    }
}
