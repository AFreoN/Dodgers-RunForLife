using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class loadBar : MonoBehaviour
{ 
    public int LoadingSceneNum;
    public Text loadingText;
    public Slider sliderBar;
    public GameObject panel;
    private AsyncOperation async;
    public GameObject exitPanel;
  //  public GameObject objCamera;
    public GameObject optionsPanel;

    public GameObject shopanimImg;
    public GameObject backFromShop;
    public GameObject[] ps;

    // Use this for initialization
    void Start()
    {
        shopanimImg.SetActive(false);
        backFromShop.SetActive(true);
        if (PlayerPrefs.GetInt("Demo") == 0)
        {
            PlayerPrefs.SetInt("Demo", 1);
        }
        for(int i=0;i<ps.Length;i++)
        {
            ps[i].SetActive(true);
        }
        Time.timeScale = 1;
        //Hide Slider Progress Bar in start

    }
    public void startGame(int sceneNum)
    {
        panel.SetActive(true);
        optionsPanel.SetActive(false);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].SetActive(false);
        }
        loadingText.text = "Loading...";
        StartCoroutine(startLoad(sceneNum));
    }
    IEnumerator startLoad(int BIndex)
    {
        yield return new WaitForSeconds(0.1f);
        Application.backgroundLoadingPriority = ThreadPriority.High;
        async = SceneManager.LoadSceneAsync(BIndex, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            float pp = async.progress * 100 / 0.9f;
            int progress = (int)Math.Ceiling(pp);
            sliderBar.value = async.progress / 0.9f;
            loadingText.text = progress + "%";
            if (async.progress >= 0.9f)
            {
                Time.timeScale = 1;
                async.allowSceneActivation = true;
                yield return null;
            }
        }
    }

    public void starting()
    {
        async.allowSceneActivation = true;
    }

    public void options()
    {
        optionsPanel.SetActive(true);
        exitPanel.SetActive(false);
        AudioManager.instance.Play("Click");
    }

    public void exitOptions()
    {
        optionsPanel.SetActive(false);
        AudioManager.instance.Play("Back");
    }
    public void Exit()
    {
        AudioManager.instance.Play("Click");
        exitPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void yesbtn()
    {
        Application.Quit();
    }
    public void noBtn()
    {
        exitPanel.SetActive(false);
        AudioManager.instance.Play("Back");
    }

    public void Shop()
    {
        // objCamera.SetActive(false);
        AudioManager.instance.Play("Click");
        shopanimImg.SetActive(true);
        StartCoroutine(navtoShop());
    }
    IEnumerator navtoShop()
    {
        yield return new WaitForSeconds(0.69f);
        SceneManager.LoadScene(3);
    }

}
