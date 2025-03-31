using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform player;  
    public float speed = 5f;  
    public float offsetX = 2f; 

    private bool movingRight = true; 

    void Update()
    {
        if (player == null) return; 


        float targetX = player.position.x + (movingRight ? offsetX : -offsetX);
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

      
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

   
    public void FlipCameraDirection()
    {
        movingRight = !movingRight;
    }
}
