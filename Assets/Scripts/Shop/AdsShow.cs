using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsShow : MonoBehaviour
{
    public GameObject ErrorImage;
    public GameObject praiseImage;
    public GameObject canvas;
    public Text msg;
    public Transform makesure;

    private void Start()
    {
        ErrorImage.SetActive(false);
        praiseImage.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Transform ms = Instantiate(makesure, canvas.transform, false);
            ms.localScale = new Vector3(0.7f, 0.7f, 1);
            AudioManager.instance.Play("NotEnough");
        }
    }

    public void showAd()
    {
        if(Advertisement.IsReady())
        {
            AudioManager.instance.Stop("MainTheme");
            Advertisement.Show("rewardedVideo",new ShowOptions() { resultCallback = HandleAdResult });
        }
        else
        {
            Transform ms = Instantiate(makesure, canvas.transform, false);
            ms.localScale = new Vector3(0.7f, 0.7f, 1);
            AudioManager.instance.Play("NotEnough");
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        AudioManager.instance.Play("MainTheme");
        switch(result)
        {
            case ShowResult.Finished:
                praiseImage.SetActive(true);
                PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 10000);
                break;
            case ShowResult.Skipped:
                msg.text = "You have not Fully Watched the AD";
                break;
            case ShowResult.Failed:
                ErrorImage.SetActive(true);
                msg.text = "Make sure u connected to the Internet?";
                break;
        }
    }
}
