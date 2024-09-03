using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BootLoad : MonoBehaviour
{
    int num;
    private void Awake()
    {
        num = PlayerPrefs.GetInt("Demo", 0);
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2.2f);
        if (num != 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }
}
