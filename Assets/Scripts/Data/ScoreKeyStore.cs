using UnityEngine;
using UnityEngine.UI;

public class ScoreKeyStore : MonoBehaviour
{
    public Text ScoreDisplay;
    public Text coinsTaken;

	// Use this for initialization
	void OnEnable ()
    {
        if (Score.HighScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score.HighScore);
            ScoreDisplay.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            ScoreDisplay.text = Score.HighScore.ToString();
        }
        coinsTaken.text = CoinSpawn.coins.ToString();
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + CoinSpawn.coins);

	}
	
}
