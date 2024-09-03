using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoPauseExit : MonoBehaviour
{
    public GameObject panel;
    public GameObject btnPanel;
    public static bool timescale;
    public GameObject gameOverPanel;

    public Transform player;
    public static Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        timescale = false;
        panel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void pauseBtn()
    {
        playerPos = player.position;
        timescale = true;
        PlayerMovement2.speeder = 0;
        Time.timeScale = 0;
        panel.SetActive(true);
        btnPanelChoose();
    }
    public void btnPanelChoose()
    {
        btnPanel.SetActive(false);
    }

    public void resume()
    {
        player.position = playerPos;
        btnPanelChoo();
        panel.SetActive(false);
        timescale = false;
        Time.timeScale = 1;
        PlayerMovement2.speeder = 5;
    }
    public void btnPanelChoo()
    {
        btnPanel.SetActive(true);
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
