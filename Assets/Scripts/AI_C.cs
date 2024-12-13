using UnityEngine;

public class AI_C : MonoBehaviour
{

    // Gameobject access
    public GameObject player;

    //speed to adjust the level....
    public float speed;

    // distance to keep calculating the players transform
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Calculating the distance with simple math that returns the current position of player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 6)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
