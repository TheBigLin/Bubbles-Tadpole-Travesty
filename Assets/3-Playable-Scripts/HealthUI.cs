using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthPrefab;
    public Sprite fullheartsprite;
    public Sprite emptyheartsprite;

    private List<Image> hearts = new List<Image>();

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
            newHeart.color = Color.red;
            hearts.Add(newHeart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullheartsprite;
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].sprite = emptyheartsprite;
                hearts[i].color = Color.white;
            }
        }
    }
}
