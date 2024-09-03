using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopNav : MonoBehaviour
{
    public GameObject WatchADPnl;
    public GameObject errorImg;
    public GameObject praiseImg;

    public GameObject shopBackAnim;

    private void Start()
    {
        WatchADPnl.SetActive(false);
        shopBackAnim.SetActive(false);
    }
    private void Update()
    {
        Application.targetFrameRate = 60;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            shopBackAnim.SetActive(true);
            StartCoroutine(exit());
        }
    }

    public void exitShop()
    {
        AudioManager.instance.Play("Back");
        shopBackAnim.SetActive(true);
        StartCoroutine(exit());
    }
    IEnumerator exit()
    {
        yield return new WaitForSeconds(0.69f);
        SceneManager.LoadScene(1);
    }
    public void moreCoins()
    {
        WatchADPnl.SetActive(true);
        AudioManager.instance.Play("Click");
    }
    public void closeMore()
    {
        WatchADPnl.SetActive(false);
        AudioManager.instance.Play("Back");
    }
    public void closeError()
    {
        errorImg.SetActive(false);
    }
    public void closePraise()
    {
        praiseImg.SetActive(false);
    }
}
