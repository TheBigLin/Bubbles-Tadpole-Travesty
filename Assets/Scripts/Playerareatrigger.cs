using UnityEngine;

public class Playerareatrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        areatrigger area = collision.GetComponent<areatrigger>();

    }
}

    
