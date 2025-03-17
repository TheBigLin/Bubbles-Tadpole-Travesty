using UnityEngine;
using System.Collections;
public class RandomJump : MonoBehaviour
{
    //public float jumpForce = Random.Range(5f,10f);         
    public float minJumpDelay = 2f;     
    public float maxJumpDelay = 7f;     

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpRandomly());
    }

    IEnumerator JumpRandomly()
    {
        while (true)
        {
            
            float delay = Random.Range(minJumpDelay, maxJumpDelay);
            yield return new WaitForSeconds(delay);

            
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(2f, 6f));
        }
    }
}
