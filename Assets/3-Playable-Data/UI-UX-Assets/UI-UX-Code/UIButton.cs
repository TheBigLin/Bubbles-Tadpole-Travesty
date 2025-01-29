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

    public void ResumeScene() 
    {
        PauseMenu.SetActive(false);
    }

}
