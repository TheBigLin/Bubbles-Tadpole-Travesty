using UnityEngine;

public class FALLTHROUGHTILES : MonoBehaviour
{

    public float playertimer = 30.0f; // how long the player has to stand (in seconds)
    public float timeforfall = 0f; //timer for player
    //public bool playerOnTile = false;
    public void TIMERSETUP(Collider other)
    {
        // Check if the player is the one standing on the tile
        if (other.CompareTag("Player"))
        {
            //playerOnTile = true;
            timeforfall += Time.deltaTime; // Increase the timer


            if (timeforfall >= playertimer)
            {
                FallThroughNow();
                Debug.Log("Collider-For-Tile-Disables");
            }
        }
    }
    public void FallThroughNow()
    {

        GetComponent<Collider>().enabled = false;


    }
}