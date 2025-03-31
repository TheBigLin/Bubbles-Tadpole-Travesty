using UnityEngine;

public class Jump : MonoBehaviour
{
    public float targetX = 10f; 
    public float moveSpeed = 5f; 
    public float verticalAmp = 2f; 
    public float verticalFreq = 1f; 

    private Rigidbody2D rb;
    private Vector2 startPos;

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();

     
        startPos = transform.position;
    }

    void Update()
    {
       
        if (transform.position.x < targetX)
        {
            
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            // Applied sine wave again motion for the vertical movement
            float sineWaveY = Mathf.Sin(Time.time * verticalFreq) * verticalAmp;
            transform.position = new Vector2(transform.position.x, startPos.y + sineWaveY);
        }
        else
        {
            // Teleport lizdini back to the start position i set.
            transform.position = startPos;
        }
    }
}
