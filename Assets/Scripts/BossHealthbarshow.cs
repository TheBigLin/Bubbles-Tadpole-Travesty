using UnityEngine;
using UnityEngine.UI;

public class BossHealthbarshow : MonoBehaviour
{
    public Slider healthBar;

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (healthBar != null)
            {
                healthBar.gameObject.SetActive(true);
            }
        }
    }
}

