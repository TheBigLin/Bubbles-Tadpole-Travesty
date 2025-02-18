using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealthTimur : MonoBehaviour
{
    public int maxhealth = 5;
    private int currentHealth;
    public int Respawn;

    public HealthUI healthUI;
    void Start()
    {
        currentHealth = maxhealth;
        healthUI.SetMaxHearts(maxhealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyAI enemy = collision.GetComponent<EnemyAI>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Zero-Health");
            SceneManager.LoadScene("UI-UX-D1-GO");
        }
    }
}