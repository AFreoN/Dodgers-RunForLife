using UnityEngine;
using UnityEngine.SceneManagement;

public class NavMainMenu : MonoBehaviour
{
    public GameObject exitpanel;
    public GameObject optionsPanel;

	void Start ()
    {
        exitpanel.SetActive(false);
        AudioManager.instance.Play("MainTheme");
	}
	
	void Update ()
    {
        Application.targetFrameRate = 60;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitpanel.activeInHierarchy == false)
            {
                AudioManager.instance.Play("Click");
            }
            exitpanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
	}
    public void trainer()
    {
        SceneManager.LoadScene(5);
    }
}
