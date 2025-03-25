using UnityEngine;

public class AI_C : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public int damage = 1;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    public int enemyHealth = 3;

    public GameObject Wasp;

    private void Update()
    {
        distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (distance < 6)
        {
            
            Vector3 newPosition = transform.position;
            if (transform.position.x < player.transform.position.x)
            {
                newPosition.x += speed * Time.deltaTime;
            }
            else if (transform.position.x > player.transform.position.x)
            {
                newPosition.x -= speed * Time.deltaTime;
            }
            transform.position = newPosition;
        }
    }


    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy health: " + enemyHealth);

        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
            Destroy(Wasp);
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
}
