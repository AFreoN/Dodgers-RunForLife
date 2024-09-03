using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropdownAudio : MonoBehaviour {

	// Use this for initialization
	void OnEnable ()
    {
        AudioManager.instance.Play("Dropdown");
	}

}
