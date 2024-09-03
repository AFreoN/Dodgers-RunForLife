using UnityEngine;
using UnityEngine.UI;

public class AudioPause : MonoBehaviour
{
    public Toggle AudioToggle;

	void Start ()
    {
        int num = PlayerPrefs.GetInt("Audio", 1);
        if(num == 1)
        {
            AudioToggle.isOn = true;
            AudioListener.pause = false;
        }
        else
        {
            AudioToggle.isOn = false;
            AudioListener.pause = true;
        }
	}
	public void  onToggleChanged(bool isON)
    {
        AudioListener.pause = !isON;
        if(isON == true)
        {
            PlayerPrefs.SetInt("Audio", 1);
        }
        else if(isON == false)
        {
            PlayerPrefs.SetInt("Audio", 0);
        }
    }
}
