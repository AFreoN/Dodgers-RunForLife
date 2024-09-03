using UnityEngine;

public class powerbutton : MonoBehaviour
{
    private int modelnum;
    public GameObject[] player;
    public GameObject SPBlocker;

    void Start ()
    {
        modelnum = PlayerPrefs.GetInt("CurrentModel", 0);
        SPBlocker.SetActive(false);
    }

    private void Update()
    {
        if(PlayerProperties.death == false && SPBlocker.activeInHierarchy == true)
        {
            SPBlocker.SetActive(false);
        }
        else if (PlayerProperties.death == true && SPBlocker.activeInHierarchy == false)
        {
            SPBlocker.SetActive(true);
        }
    }
    public void PowerON()
    {
        AudioManager.instance.Play("SPbtn");
        switch(modelnum)
        {
            case 1:
                player[modelnum - 1].GetComponent<KnightSP>().powerAction();
                break;
            case 2:
                player[modelnum - 1].GetComponent<MutantSP>().powerAction();
                break;
        }
    }
}
