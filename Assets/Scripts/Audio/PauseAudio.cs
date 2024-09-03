using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAudio : MonoBehaviour {
    int audioNum;

    private void OnEnable()
    {
        audioNum = PlayerPrefs.GetInt("Audio", 1);
        if (audioNum == 1)
        {
            AudioListener.pause = true;
            AudioManager.instance.Pause("Main");
        }
        Debug.Log(audioNum);
    }
    private void OnDisable()
    {
        if (audioNum == 1)
        {
            AudioListener.pause = false;
        }
    }
}
