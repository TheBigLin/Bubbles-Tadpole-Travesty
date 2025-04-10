using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenDemo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LevelDemo());
    }

    IEnumerator LevelDemo()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("LevelOne");
    }
}
