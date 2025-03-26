using UnityEngine;

public class EatFly : MonoBehaviour
{
    [SerializeField] private AudioSource eatFlySound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            eatFlySound.Play();
            Destroy(other.gameObject);
        }

    }
}
