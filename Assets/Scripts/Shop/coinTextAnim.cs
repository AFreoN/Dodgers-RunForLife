using UnityEngine;
using UnityEngine.UI;

public class coinTextAnim : MonoBehaviour {

    private int TotalCoins;
    private Animator anim;
    private int currentCoins;
    public Text myString;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        currentCoins = TotalCoins;
    }
    private void Update()
    {
        currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (TotalCoins < currentCoins)
        {
            int finalCoins = currentCoins - TotalCoins;
            myString.text = "+" + finalCoins.ToString();
            anim.SetTrigger("Go1");
            TotalCoins = currentCoins;
        }
        else if(TotalCoins > currentCoins)
        {
            int finalCoins = TotalCoins - currentCoins;
            myString.text = "-" + finalCoins.ToString();
            anim.SetTrigger("Go");
            TotalCoins = currentCoins;
        }
    }
}
