using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    //My Variables.
    public float EnmSpeed = 5f;
    //public float rightdistance = Random.Range(5f,11f); 
    //public float leftdistance = Random.Range(-5f,-9f);

    private SpriteRenderer mysprite;

    private float direction = 1f;
    private void Start()
    {
        mysprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    { 

    //
    transform.position += Vector3.right* direction * EnmSpeed* Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightT"))
        {
            //if (transform.position.x <= 100f)
            //{
                Debug.Log("TurnL");
                //
                direction = -1f;
                mysprite.flipX = false;
            //}
        }
        if (collision.gameObject.CompareTag("LeftT"))
            //if (transform.position.x >= -112f)
            //{
                {
                    //
                    Debug.Log("TurnR");
                    direction = 1f;
                    mysprite.flipX = true;
                }
            //}
    }
}
