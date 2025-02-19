using UnityEngine;

public class AI_KOTD : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public int damage = 1;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
