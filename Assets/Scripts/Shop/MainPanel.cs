using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour {

    private int num;
    public Text coins;
	// Use this for initialization
	void Start ()
    {
        coins.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        num = PlayerPrefs.GetInt("TotalCoins");
	}
	
	// Update is called once per frame
	void Update ()
    {
        coins.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        int currentNum = PlayerPrefs.GetInt("TotalCoins");
        if(currentNum != num)
        {
            AudioManager.instance.Play("CoinOut");
            num = currentNum;
        }
    }
}
