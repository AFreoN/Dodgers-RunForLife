using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowNav : MonoBehaviour
{
    private float[] waitTime= { 14f,7.9f };

    private void Start()
    {
        int modelNum = PlayerPrefs.GetInt("showModel");
        StartCoroutine(EscapeScene(waitTime[modelNum]));
    }
    IEnumerator EscapeScene(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (GameObject g in SceneManager.GetSceneByBuildIndex(3).GetRootGameObjects())
        {
            g.SetActive(true);
        }
        SceneManager.UnloadSceneAsync(4);
    }
    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.touchCount > 0)
        {
            foreach (GameObject g in SceneManager.GetSceneByBuildIndex(3).GetRootGameObjects())
            {
                g.SetActive(true);
            }
            SceneManager.UnloadSceneAsync(4);
        }
	}
}
