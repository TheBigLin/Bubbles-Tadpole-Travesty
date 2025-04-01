using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseTheGame = false;
    public GameObject PauseMenuUX;
    public GameObject Bu;
    public GameObject Camera2;

    //public MonoBehaviour PlayerMovement;

    //public PlayerMovement script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseMenuUX.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause if the game is not pause
            if (PauseTheGame)
            {
                Time.timeScale = 1;
                PauseTheGame = false;
                PauseMenuUX.SetActive(true);
                Bu.SetActive(false);
                Camera2.SetActive(true);
                //PlayerMovement.enabled = false;

            }
            //pause
            else
            {
                //Pause the 
                Time.timeScale = 0;
                PauseTheGame = true;
                PauseMenuUX.SetActive(false);
                Bu.SetActive(true);
                Camera2.SetActive(false);
                //PlayerMovement.enabled = true;
            }
        }
    }
}
