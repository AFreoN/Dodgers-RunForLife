using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyData : MonoBehaviour
{
    public Text HighScore;
    public Text TotalCoins;

	// Use this for initialization
	void Start ()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        TotalCoins.text = PlayerPrefs.GetInt("TotalCoins").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
