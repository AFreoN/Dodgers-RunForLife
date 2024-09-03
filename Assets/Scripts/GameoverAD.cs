using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameoverAD : MonoBehaviour
{
    public Image continueAD;
    private float currentTime;
    private bool activate;

    public GameObject continueBtn;
    public GameObject restartBtn;
    public GameObject[] players;
    public Animator[] anim;
    private int modelnum;

    public GameObject BtnPanel;
    public GameObject medium;
    public GameObject large;

    public Transform makeSure;

    void OnEnable()
    {
        if (PauseExit.adsShowed == 0)
        {
            PauseExit.timescale = true;
            restartBtn.SetActive(false);
            continueBtn.SetActive(true);
            modelnum = PlayerPrefs.GetInt("CurrentModel", 0);
            activate = true;
            currentTime = Time.time;
            continueAD.fillAmount = 1;
            AudioManager.instance.Play("untitle");
            StartCoroutine(closeContinue());
        }
        else
        {
            PauseExit.timescale = true;
            restartBtn.SetActive(true);
            continueBtn.SetActive(false);
            modelnum = PlayerPrefs.GetInt("CurrentModel", 0);
            activate = false;
            currentTime = Time.time;
            continueAD.fillAmount = 1;
            AudioManager.instance.Play("untitle");
        }
        PauseExit.adsShowed += 1;
	}

    IEnumerator closeContinue()
    {
        yield return new WaitForSeconds(2.5f);
        activate = false;
        restartBtn.SetActive(true);
        continueBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void showAdToContinoue()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResults });
            StartCoroutine(whileShowing());
        }
        else
        {
            Transform ms = Instantiate(makeSure, gameObject.transform, false);
            ms.transform.SetParent(gameObject.transform);
            AudioManager.instance.Play("error");
        }
    }
    IEnumerator whileShowing()
    {
        while(Advertisement.isShowing)
        {
            Time.timeScale = 0;
            yield return null;
        }
    }

    private void HandleAdResults(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                PauseExit.timescale = false;
                Time.timeScale = PlayerProperties.timer;
                AudioManager.instance.Stop("untitle");
                AudioManager.instance.Play("Main");
                players[modelnum].transform.position = new Vector3(0, 0, players[modelnum].transform.position.z);
                LowPlane.follow = true;
                btnPanelChoose();
                PlayerProperties.death = false;
                PlayerProperties.ghostSP = true;
                anim[modelnum].SetBool("Run",true);
                PlayerMovement.speeder = 5;
                PlayerMovement1.speeder = 5;
                PlayerMovement2.speeder = 5;
                gameObject.SetActive(false);
                PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - CoinSpawn.coins);
                break;
            case ShowResult.Skipped:
                Debug.Log("Shipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Failed");
                break;
        }
    }
    public void btnPanelChoose()
    {
        if (PlayerProperties.btnCount == 0)
        {
            BtnPanel.SetActive(true);
            medium.SetActive(false);
            large.SetActive(false);
        }
        if (PlayerProperties.btnCount == 1)
        {
            medium.SetActive(true);
            BtnPanel.SetActive(false);
            large.SetActive(false);
        }
        if (PlayerProperties.btnCount == 2)
        {
            large.SetActive(true);
            BtnPanel.SetActive(false);
            medium.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if(activate == true)
        {
            continueAD.fillAmount = 1-(Time.time - currentTime)/2.5f;
        }
        else
        {
            continueAD.fillAmount = 0;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Transform ms = Instantiate(makeSure, gameObject.transform,false);
            ms.transform.SetParent(gameObject.transform);
            AudioManager.instance.Play("error");
        }
	}
}
