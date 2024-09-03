using UnityEngine;

public class charChoose : MonoBehaviour
{
    public GameObject[] characters;

    void Start ()
    {
        int modelnum = PlayerPrefs.GetInt("showModel");
        for (int i = 0; i < characters.Length; i++)
        {
            if (modelnum == i)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }

}
