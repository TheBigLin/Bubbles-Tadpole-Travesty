using UnityEngine;

public class BubblesTrickedAnimation : MonoBehaviour
{
    public GameObject RunSprite;
    public SpriteRenderer Sprite;
    public bool SpriteCoord = true;
    // Update is called once per frame
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the animation
            animator.SetTrigger("Bubble_Animation_Control");
        }
    }
    public void TurnTheSprite()
    {
        SpriteCoord = !SpriteCoord;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
