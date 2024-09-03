using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseExit : MonoBehaviour
{
    public GameObject panel;
    public GameObject btnPanel;
    public GameObject medium;
    public GameObject large;
    public static bool timescale;
    public GameObject gameOverPanel;
    private int btnCount;

    public Transform[] player;
    private int ModelNum;
    public static Vector3 playerPos;
    public static int adsShowed;
    int audioNum;

	// Use this for initialization
	void Start ()
    {
        ModelNum = PlayerPrefs.GetInt("CurrentModel", 0);
        audioNum = PlayerPrefs.GetInt("Audio", 1);
        timescale = false;
        btnCount = PlayerPrefs.GetInt("btnSize", 0);
        panel.SetActive(false);
        gameOverPanel.SetActive(false);
        adsShowed = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseBtn();
        }
    }
    public void pauseBtn()
    {
        playerPos = player[ModelNum].position;
        timescale = true;
        PlayerMovement.speeder = 0;
        PlayerMovement1.speeder = 0;
        PlayerMovement2.speeder = 0;
        Time.timeScale = 0;
        panel.SetActive(true);
        btnPanelChoose();
    }
    public void btnPanelChoose()
    {
        if (btnCount == 0)
        {
            btnPanel.SetActive(false);
        }
        if (btnCount == 1)
        {
            medium.SetActive(false);
        }
        if (btnCount == 2)
        {
            large.SetActive(false);
        }
    }

    public void resume()
    {
        player[ModelNum].position = playerPos;
        btnPanelChoo();
        if (audioNum == 1)
        {
            AudioManager.instance.Play("Main");
        }
        else
        {
            AudioListener.pause = true;
        }
        panel.SetActive(false);
        timescale = false;
        Time.timeScale = PlayerProperties.timer;
        PlayerMovement.speeder = 5;
        PlayerMovement1.speeder = 5;
        PlayerMovement2.speeder = 5;
    }
    public void btnPanelChoo()
    {
        if (btnCount == 0)
        {
            btnPanel.SetActive(true);
        }
        if (btnCount == 1)
        {
            medium.SetActive(true);
        }
        if (btnCount == 2)
        {
            large.SetActive(true);
        }
    }
    public void backBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void restart()
    {
        SceneManager.LoadScene(2);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(1);
    }
}
