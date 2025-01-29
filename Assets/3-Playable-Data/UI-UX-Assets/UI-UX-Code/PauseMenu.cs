using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseTheGame = false;
    public GameObject PauseMenuUX;

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
                PauseMenuUX.SetActive(false);
            }
            //pause
            else
            {
                //Pause the 
                Time.timeScale = 0;
                PauseTheGame = true;
                PauseMenuUX.SetActive(true);
            }
        }
    }
}
