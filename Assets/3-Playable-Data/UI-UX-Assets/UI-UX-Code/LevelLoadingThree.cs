using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingThree : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LevelThree());
    }

    IEnumerator LevelThree()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("LevelThree");
    }
}
