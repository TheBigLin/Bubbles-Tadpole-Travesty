using System.Collections;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    public float fallWait = 2f;
    public float destroyWait = 1f;
    public GameObject T;
    bool isFalling;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            T.SetActive(false);
            T.SetActive(true);
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rb.bodyType = RigidbodyType2D.Dynamic;

        //Wait-then-Destroy:
        Destroy(gameObject, destroyWait);
    }
}

