using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class DemoScore : MonoBehaviour
{
    public Transform player;
    public GameObject demoPanel;
    public Text score;
    private int calc;
    public static int HighScore;
    private int modelNum;

    public Text coinsTaken;

    void Start()
    {
        calc = (int)Math.Ceiling(player.position.z * 1.5f);
        score.text = calc.ToString();
        demoPanel.SetActive(false);
        StartCoroutine(ShowDemo());
    }
    IEnumerator ShowDemo()
    {
        yield return new WaitForSeconds(2);
        demoPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        calc = (int)Math.Ceiling(player.position.z * 1.5f);
        HighScore = calc;
        if (PlayerProperties.death == false)
        {
            score.text = calc.ToString();
            coinsTaken.text = CoinSpawn.coins.ToString();
        }
    }
}
