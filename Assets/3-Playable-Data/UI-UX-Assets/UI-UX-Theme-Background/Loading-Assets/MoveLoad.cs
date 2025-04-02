using System.Collections;
using UnityEngine;

public class MoveLoad : MonoBehaviour
{
    public GameObject Get;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(LoadRun());
    }

    IEnumerator LoadRun() 
    {
        yield return new WaitForSeconds(1.3f);
        Get.transform.position = new Vector3(-6.207f, -3.77f, .0f);
        yield return new WaitForSeconds(1.3f);
        Get.transform.position = new Vector3(-0.33f, -3.77f, .0f);
        yield return new WaitForSeconds(1.3f);
        Get.transform.position = new Vector3(4.66f, -3.77f, .0f);
        yield return new WaitForSeconds(1.3f);
        Get.transform.position = new Vector3(8.27f, -3.77f, .0f);
    }
}
