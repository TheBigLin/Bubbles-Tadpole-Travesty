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
        SceneManager.LoadScene("Prologue");
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
        SceneManager.LoadScene("LevelOne");
    }
        public void ResetGame2()
    {
        SceneManager.LoadScene("LevelTwo");
    }
        public void ResetGame3()
    {
        SceneManager.LoadScene("LeveThree");
    }

        public void ResetGameDemo()
    {
        SceneManager.LoadScene("Demo-Scene");
    }
    public void ExitFromCredit() 
    {
        SceneManager.LoadScene("UI-UX-D1-Menu");

    }

    public void QuitBackToMainmenu()
    {
        SceneManager.LoadScene("UI-UX-D1-Menu");
    }
        public void QuitBackToMainmenu1()
    {
        SceneManager.LoadScene("UI-UX-D1-Menu1");
    }


    public void ExitGame() 
    {
        Application.Quit();
        Debug.Log("Exit!!!!---");
    }

}
