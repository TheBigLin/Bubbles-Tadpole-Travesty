using UnityEngine;
using UnityEngine.UI;

public class BossHealthbarshow : MonoBehaviour
{
    public Slider healthBar;
    [SerializeField] private AudioSource bossSound;

    private bool hasTriggered = false; 

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            if (healthBar != null)
            {
                healthBar.gameObject.SetActive(true);
            }

            if (bossSound != null && !bossSound.isPlaying)
            {
                bossSound.Play();
            }
        }
    }
}
