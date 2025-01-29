using System.Collections;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    public float fallWait = 2f;
    public float destroyWait = 1f;
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
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        //Wait-then-Destroy:
        Destroy(gameObject, destroyWait);
    }
}

