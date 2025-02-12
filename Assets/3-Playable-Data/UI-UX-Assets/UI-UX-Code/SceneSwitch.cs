using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PortalTwo"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Level-Two");
            //Start-lEVEL-tWO
            StartCoroutine(loading());
  
        }

        if (other.gameObject.CompareTag("PortalThree"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Level-Three");   
            //Start-lEVEL-tHREE
            StartCoroutine(loading1());
        }
    }



    IEnumerator loading() 
    {
        yield return new WaitForSeconds(0.1f);
        //Loading-screen
        SceneManager.LoadScene("Loading-Screen-1");
        //Time-to-load
    }
    IEnumerator loading1()
    {
        yield return new WaitForSeconds(0.1f);
        //Loading-screen
        SceneManager.LoadScene("Loading-Screen-2");
        //Time-to-load
    }
}