using UnityEngine;

public class CharDisplay : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject charSP;
    public GameObject powerBtn;

	void Start ()
    {
        int modelnum= PlayerPrefs.GetInt("CurrentModel", 0);
        for(int i=0;i < characters.Length;i++)
        {
            if(modelnum == i)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
        if(modelnum > 0)
        {
            charSP.SetActive(true);
            powerBtn.SetActive(true);
        }
        else
        {
            charSP.SetActive(false);
            powerBtn.SetActive(false);
        }
    }
	
}
