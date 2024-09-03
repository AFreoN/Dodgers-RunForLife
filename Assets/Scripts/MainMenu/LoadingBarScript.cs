using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadingBarScript : MonoBehaviour
{

    public int LoadingSceneNum;
    public Text loadingText;
    public Slider sliderBar;
    public GameObject panel;
    private AsyncOperation async;
    public GameObject exitPanel;
    public GameObject optionsPanel;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start ()
    {
        //Hide Slider Progress Bar in start
        Time.timeScale = 1;
        exitPanel.SetActive(false);
        optionsPanel.SetActive(false);
        panel.SetActive(false);
	}

    public void startGame(int sceneNum)
    {
        panel.SetActive(true);
        loadingText.text = "Loading...";
        StartCoroutine(startLoad(sceneNum));
    }
    IEnumerator startLoad(int BIndex)
    {
        async = SceneManager.LoadSceneAsync(BIndex,LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            float pp = async.progress * 100 / 0.9f;
            int progress = (int)Math.Ceiling(pp);
            sliderBar.value = async.progress / 0.9f;
            loadingText.text = progress + "%";
            if(async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {


    }
    public void options()
    {
        optionsPanel.SetActive(true);
    }

    public void exitOptions()
    {
        optionsPanel.SetActive(false);
    }
    public void Exit()
    {
        exitPanel.SetActive(true);
    }
    public void yesbtn()
    {
        Application.Quit();
    }
    public void noBtn()
    {
        exitPanel.SetActive(false);
    }

}
