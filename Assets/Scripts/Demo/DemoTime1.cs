using UnityEngine;

public class DemoTime1 : MonoBehaviour {

    public GameObject pauseBtn;
    public static bool powered;

    private void Start()
    {
        pauseBtn.SetActive(false);
        powered = false;
    }
    public void timer1()
    {
        Time.timeScale = 1;
    }
    public void timer2()
    {
        Time.timeScale = 1;
        SequenceofDemo.timeControl = false;
        powered = true;
    }
}
