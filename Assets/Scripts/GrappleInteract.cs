using UnityEngine;
using static Unity.Collections.Unicode;

public class GrappleInteract : MonoBehaviour
{
    public GameObject Canvas;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.SetActive(false);
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playerareatrigger player = collision.GetComponent<Playerareatrigger>();
        if (player != null) // it is a player
        {
           
            Canvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Playerareatrigger player = collision.GetComponent<Playerareatrigger>();
        if (player != null) // it is a player
        {
           
            Canvas.SetActive(false);
            
        }
    }
}
