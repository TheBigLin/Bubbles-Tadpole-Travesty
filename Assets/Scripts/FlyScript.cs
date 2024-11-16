using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float speed = 2.0f;   // Base movement speed of the fly
    public float directionChangeTime = 0.5f; // How often the fly changes direction
    public Vector2 movementBounds = new Vector2(3.0f, 2.0f); // Horizontal and vertical limits from the starting position

    private Vector2 movementDirection;
    private Vector2 startPosition;    // Original position of the fly
    private float timer;

    void Start()
    {
        startPosition = transform.position; // Keep the starting position
        SetRandomDirection();
    }

    void Update()
    {
        // Update the fly's position
        Vector2 newPosition = (Vector2)transform.position + movementDirection * speed * Time.deltaTime;

        // Keep fly within bounds
        newPosition.x = Mathf.Clamp(newPosition.x, startPosition.x - movementBounds.x, startPosition.x + movementBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, startPosition.y - movementBounds.y, startPosition.y + movementBounds.y);

        // Apply the bounds position to game
        transform.position = newPosition;

        // Uses timer set as an interval before fly changes position
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        // Randomize direction and reset timer
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        timer = directionChangeTime;
    }
}
