using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text loadingText;

    AsyncOperation async;

    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadScreen()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        Debug.Log(async.progress);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            slider.value = async.progress / 0.9f;
            loadingText.text = Mathf.CeilToInt(async.progress * 100 / 0.9f).ToString();
            Debug.Log(slider.value);
        }
        async.allowSceneActivation = true;
        yield return null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
