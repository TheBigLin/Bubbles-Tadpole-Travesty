using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner.onNodeStart.AddListener(OnNodeStart);
    }

    void OnNodeStart(string nodeName)
    {
        // Check for the specific node that triggers the scene switch
        if (nodeName == "SwitchSceneNode")
        {
            Debug.Log("Switching to the next scene...");
            SceneManager.LoadScene("A"); // target scene name
        }
    }

    void OnDestroy()
    {
        dialogueRunner.onNodeStart.RemoveListener(OnNodeStart);
    }
}