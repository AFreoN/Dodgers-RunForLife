using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdsPnl : MonoBehaviour {

    public GameObject errorImg;
    public GameObject praiseImg;
	// Use this for initialization
	void Start ()
    {
        errorImg.SetActive(false);
        praiseImg.SetActive(false);
	}
    private void OnEnable()
    {
        errorImg.SetActive(false);
        praiseImg.SetActive(false);
    }
}
