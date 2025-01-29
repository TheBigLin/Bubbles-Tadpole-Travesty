using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public GameObject PauseMenu; 
    //Class_For_Buttons
    public void SwitchPlayScene() 
    {      
        //Using_The_Unity_Scene_Manager
        //Scene_Load_A
        SceneManager.LoadScene("A");
    }

    //Class_For_Credit_Button
    public void CreditsPlayScene() 
    {
        SceneManager.LoadScene("UI-UX-D1-Credits");
    }
    //Resume-For-Continue-Button
    public void ResumeScene() 
    {
        PauseMenu.SetActive(false);
    }
    //Go-Back-to-Menu
    public void ResetGame()
    {
        SceneManager.LoadScene("UI-UX-D1-Menu");
    }

}
