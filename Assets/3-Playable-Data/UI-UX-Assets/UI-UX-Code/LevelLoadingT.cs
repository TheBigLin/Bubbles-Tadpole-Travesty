using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingT : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LevelTwo());
    }

    IEnumerator LevelTwo() 
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("LevelTwo");
    }
}
