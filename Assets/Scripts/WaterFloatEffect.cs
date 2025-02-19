using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterFloatEffect : MonoBehaviour
{
    public float floatStrength = 0.5f; 
    public float floatSpeed = 2.0f;    

    private bool isInWater = false; 
    private float originalY;

    private void Start()
    {
        originalY = transform.position.y;
    }

    private void Update()
    {
        if (isInWater)
        {
            float newY = originalY + Mathf.Sin(Time.time * floatSpeed) * floatStrength;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isInWater = true;
            originalY = transform.position.y; // Update the original position when entering water
            transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
            isInWater = false;
        }
    }
}