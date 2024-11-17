using UnityEngine;

using Unity.VisualScripting;


public class GrappleMechanic : MonoBehaviour

{
    public GameObject Character;
    public GameObject TriggerPoint;
    public Transform projectile; // The projectile to be launched
    public Transform anchor; // The anchor point of the slingshot
    public float maxDragDistance = 3.0f; // Maximum distance the projectile can be dragged
    public float maxLaunchForce = 1000.0f; // Maximum force applied to launch the projectile
    public KeyCode activateKey = KeyCode.E; // Key to activate the slingshot
    public float drag = 1.0f; // Drag force applied to the projectile
    public float gravity = 9.81f; // Gravity force to be applied manually

    private Vector3 initialPosition;
    private bool isDragging = false;
    private bool isActivated = false;
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = projectile.position;
        rb = projectile.GetComponent<Rigidbody2D>();
        rb.drag = drag; // Set the drag force
    }
    //public void OnCollisionEnter2D(PolygonCollider2D collision)
    ///{
    ///GetComponent<PlayerMovement>().enabled = true;
    //isActivated = false;
    //Do something
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == TriggerPoint)
        {
            GetComponent<PlayerMovement>().enabled = true;
            isActivated = false;
            Debug.Log("Collision detected with the specific GameObject!");
        }
    }


    void Update()
    {
        {
            initialPosition = projectile.position;
            rb = projectile.GetComponent<Rigidbody2D>();
            rb.drag = drag;
        }
        if (Input.GetKeyDown(activateKey))
        {
            isActivated = true;
            GetComponent<PlayerMovement>().enabled = false;
        }

        if (isActivated)
        {
            if (Input.GetKey(KeyCode.A))
            {
                DragProjectile(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                DragProjectile(Vector3.right);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                LaunchProjectile();
                isActivated = false; // Reset activation after launch
            }
        }
    }


    void DragProjectile(Vector3 direction)
    {
        isDragging = true;
        Vector3 dragPosition = projectile.position + direction * Time.deltaTime * maxDragDistance;
        dragPosition = Vector3.ClampMagnitude(dragPosition - anchor.position, maxDragDistance) + anchor.position;
        projectile.position = dragPosition;
    }
    void FixedUpdate()
    {
        if (!isDragging && rb.velocity != Vector2.zero)
        {
            ApplyGravity();
        }
    }
    void LaunchProjectile()
    {
        if (isDragging)
        {
            isDragging = false;
            Vector3 launchDirection = (anchor.position - projectile.position).normalized;
            float dragDistance = Vector3.Distance(projectile.position, anchor.position);
            float launchForce = (dragDistance / maxDragDistance) * maxLaunchForce;
            rb.AddForce(launchDirection * launchForce);
        }
    }

    void ApplyGravity()
    {
        rb.AddForce(Vector2.down * gravity * rb.mass);
    }
}