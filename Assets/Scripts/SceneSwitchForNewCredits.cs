using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad = "NewScene"; 
    public KeyCode keyToPress = KeyCode.Space; 

    void Update()
    {
        
        if (Input.GetKeyDown(keyToPress))
        {
            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
