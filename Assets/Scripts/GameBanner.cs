using UnityEngine;

public class GameBanner : MonoBehaviour
{

    public static int noofPlay;

    void Start()
    {
        noofPlay = PlayerPrefs.GetInt("noofplay", 0);
        noofPlay++;
        PlayerPrefs.SetInt("noofplay", noofPlay);
    }
}
