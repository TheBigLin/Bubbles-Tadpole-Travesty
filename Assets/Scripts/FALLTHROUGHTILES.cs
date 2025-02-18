using UnityEngine;

public class FALLTHROUGHTILES : MonoBehaviour
{

    public float playertimer = 5.0f; // how long the player has to stand (in seconds)
    public float timeforfall = 0f; //timer for player
    public GameObject Tile;
    //public bool playerOnTile = false;


    //Update-class
    public void Update()
    {
        
    }
    public void TIMERSETUP(Collider other)
    {
        // Check if the player is the one standing on the tile
        if (other.CompareTag("FallTile"))
        {
            //playerOnTile = true;
            //timeforfall += 2; // Increase the timer
            timeforfall = Time.time;

            Debug.Log("Collider");
            if (timeforfall == playertimer)
            {
                FallThroughNow();
                Debug.Log("Collider-For-Tile-Disables");
                gameObject.SetActive(false);
            }
        }
    }
    public void FallThroughNow()
    {

        //GetComponent<Collider>().enabled = false;


    }
}