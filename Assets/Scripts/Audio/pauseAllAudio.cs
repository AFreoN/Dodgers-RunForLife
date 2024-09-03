using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAllAudio : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        int num = PlayerPrefs.GetInt("Audio",1);
        if(num == 1)
        {
            AudioListener.pause = false;
        }
        else if(num == 0)
        {
            AudioListener.pause = true;
        }
    }
}
