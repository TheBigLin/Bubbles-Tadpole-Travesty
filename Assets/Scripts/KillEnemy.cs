using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wasp"))
        {
            Destroy(other.gameObject);
        }

    }
}
