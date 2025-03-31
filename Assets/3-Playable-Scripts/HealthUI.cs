using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class HealthUI : MonoBehaviour
{
    public Image healthPrefab;
    public Sprite fullheartsprite;
    public Sprite emptyheartsprite;

    public DialogueRunner dialogueRunner; 

    public AudioSource audioSource; 
    public AudioClip lowHealthSound; 

    private List<Image> hearts = new List<Image>();
    private int lastHealth = -1; 

    public void SetMaxHearts(int maxHearts)
    {
        foreach (Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }

        hearts.Clear();

        for (int i = 0; i < maxHearts; i++)
        {
            Image newHeart = Instantiate(healthPrefab, transform);
            newHeart.sprite = fullheartsprite;
            newHeart.color = Color.green;
            hearts.Add(newHeart);
        }

        lastHealth = maxHearts;
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullheartsprite;

                // make hearts red, otherwise white
                hearts[i].color = (currentHealth < 3) ? Color.red : Color.white;
            }
            else
            {
                StartCoroutine(FadeOutHeart(hearts[i]));
            }
        }

        // Play da low health sound and keep da hearts red if health is below the set threshold
        if (currentHealth < 3)
        {
            if (audioSource != null && lowHealthSound != null && !audioSource.isPlaying)
            {
                audioSource.clip = lowHealthSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            // Stop da sound and reset da heart colors when health is restored
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }

           
            foreach (var heart in hearts)
            {
                heart.color = Color.white;
            }
        }

        lastHealth = currentHealth;
    }



    private IEnumerator FadeOutHeart(Image heart) // WAIT GAG THIS WORKS
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Color startColor = heart.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            heart.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        heart.gameObject.SetActive(false);
    }
}
