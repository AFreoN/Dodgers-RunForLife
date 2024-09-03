using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Score : MonoBehaviour
{
    public Transform[] player;
    public Text score;
    private int calc;
    public static int HighScore;
    private int modelNum;

    public Text remScoreforHighText;
    public GameObject newHighScore;
    int rem;
    int high;

    public Text coinsTaken;
	// Use this for initialization
	void Start ()
    {
        newHighScore.SetActive(false);
        modelNum = PlayerPrefs.GetInt("CurrentModel", 0);
        high = PlayerPrefs.GetInt("HighScore",0);
        calc = (int)Math.Ceiling(player[modelNum].position.z * 1.5f);
        score.text = calc.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        calc = (int)Math.Ceiling(player[modelNum].position.z * 1.5f);
        HighScore = calc;
        if (PlayerProperties.death == false)
        {
            score.text = calc.ToString();
            coinsTaken.text = CoinSpawn.coins.ToString();
        }
        if(calc <= high && PlayerProperties.death == false)
        {
            rem = high - calc;
            remScoreforHighText.text = rem.ToString();
        }
        else if(calc-1 == high && high != 0)
        {
            newHighScore.SetActive(true);
            AudioManager.instance.Play("ohya");
            StartCoroutine(closenewHigh());
        }
    }
    IEnumerator closenewHigh()
    {
        yield return new WaitForSeconds(2);
        newHighScore.SetActive(false);
    }
}
