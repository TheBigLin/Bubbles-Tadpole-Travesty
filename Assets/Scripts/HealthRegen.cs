using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public int healthRestoreAmount = 1;
    [SerializeField] private AudioSource regainHealthSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                regainHealthSound.enabled = true;
                regainHealthSound.Play();
                playerHealth.RestoreHealth(healthRestoreAmount);
               
            }

            Destroy(gameObject);
        }
    }
}
