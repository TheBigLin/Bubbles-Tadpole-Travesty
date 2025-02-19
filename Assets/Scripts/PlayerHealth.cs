using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public HealthUI healthUI;
    public DialogueRunner dialogueRunner;
    private bool hasShownDamageDialogue = false;
    [SerializeField] private AudioSource takeDamageSound;

    private void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
        healthUI.UpdateHearts(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            TakeDamage(1);
            takeDamageSound.Play();
        }

        if (collision.CompareTag("WaspDamage"))
        {
            TakeDamage(1);
            takeDamageSound.Play();
            TeleportPlayer();
        }

        if (collision.CompareTag("ToadDamage"))
        {
            TakeDamage(1);
            takeDamageSound.Play();
            TeleportPlayer();
        }

        if (collision.CompareTag("KOTDDamage"))
        {
            TakeDamage(1);
            takeDamageSound.Play();
            TeleportPlayer();
        }

    }

    private void TeleportPlayer()
    {
        Vector3 safePosition = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
        transform.position = safePosition;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);


        if (!hasShownDamageDialogue && dialogueRunner != null && !dialogueRunner.IsDialogueRunning)
        {
            hasShownDamageDialogue = true;
            dialogueRunner.StartDialogue("DamageReaction");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Long Live Bubbles...");
        SceneManager.LoadScene("UI-UX-D1-GO");
    }

    public void RestoreHealth(int healthAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healthAmount, maxHealth);
        healthUI.UpdateHearts(currentHealth);
    }

}