using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBladeAudio : MonoBehaviour {

    AudioSource source;
    bool control;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start ()
    {
        control = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerProperties.death == true && control == true)
        {
            source.Stop();
            control = false;
        }
        else if (PlayerProperties.death == false && control == false)
        {
            source.Play();
            control = true;
        }
    }
}
