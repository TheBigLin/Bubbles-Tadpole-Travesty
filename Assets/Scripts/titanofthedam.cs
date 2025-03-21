using UnityEngine;
using UnityEngine.UI;

public class titanofthedam : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    public float chargeSpeed = 5f;
    public float chargeRange = 5f;
    public Transform player;
    public float chargeCooldown = 3f;
    private float nextAttackTime = 0f;
    public int health;
    public int damage;
    public float playerKnockback = 7f;
    public Slider healthBar;
    public GameObject Titanofthedam;
    private Rigidbody2D rb;

    private int currentPatrolIndex = 0;
    private int currentHealth;
    private bool isCharging;
    private float chargeTimer;
    private float lastKnownPlayerX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
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
            Destroy(Titanofthedam);
            Destroy(healthBar.gameObject);
        }
    }

    void Update()
    {
        chargeTimer += Time.deltaTime;

        if (isCharging)
        {
            Charging();
        }
        else if (player != null && Mathf.Abs(transform.position.x - player.position.x) <= chargeRange && chargeTimer >= chargeCooldown)
        {
            StartCharging();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Length < 2) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void StartCharging()
    {
        isCharging = true;
        chargeTimer = 0f;


        lastKnownPlayerX = player.position.x;
    }

    void Charging()
    {

        Vector2 targetPosition = new Vector2(lastKnownPlayerX, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, chargeSpeed * Time.deltaTime);


        if (Mathf.Abs(transform.position.x - lastKnownPlayerX) < 0.1f)
        {
            StopCharging();
        }
    }

    void StopCharging()
    {
        isCharging = false;


        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
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
                nextAttackTime = Time.time + chargeCooldown;
            }
        }
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
