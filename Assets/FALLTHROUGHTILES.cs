using UnityEngine;

public class FALLTHROUGHTILES : MonoBehaviour
{

    public float playertimer = 3.0f; // how long the player has to stand (in seconds)
    public float timeforfall = 0f; //timer for player

    private void TIMERSETUP(Collider other)
    {
        // Check if the player is the one standing on the tile
        if (other.CompareTag("Player"))
        {
            playerOnTile = true;
            timer += Time.deltaTime; // Increase the timer

          
            if (timeforfall >= FallThroughNow) ;
            {
                FallThroughNow();
            }
        }
    }
    private void FallThroughNow()
    {

        GetComponent<Collider>().enabled = false;


    }
}