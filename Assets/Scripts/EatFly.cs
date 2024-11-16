using UnityEngine;

public class EatFly : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fly"))
        {
            Destroy(other.gameObject);
        }

    }
}
