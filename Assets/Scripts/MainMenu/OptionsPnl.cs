using UnityEngine;
using UnityEngine.UI;

public class OptionsPnl : MonoBehaviour {

    public Dropdown btnSize;
    public Dropdown qualityLevel;
    public static GameObject btn;
    private int btt;
    int j = 0;

    // Use this for initialization
    void Start ()
    {
        btnSize.value = PlayerPrefs.GetInt("btnSize", 1);
        qualityLevel.value = PlayerPrefs.GetInt("QualityDropDown", 1);
    }

    // Update is called once per frame
    void Update ()
    {
        switch (btnSize.value)
        {
            case 1:
                PlayerPrefs.SetInt("btnSize", 1);
                btn = GameObject.Find("BtnPanel Medium");
                break;
            case 2:
                PlayerPrefs.SetInt("btnSize", 2);
                btn = GameObject.Find("BtnPanel Large");
                break;
            default:
                PlayerPrefs.SetInt("btnSize", 0);
                btn = GameObject.Find("BtnPanel Small");
                break;
        }

        switch (qualityLevel.value)
        {
            case 1:
                PlayerPrefs.SetInt("QualityDropDown", 1);
                PlayerPrefs.SetInt("Quality", 3);
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"), true);
                break;
            case 2:
                PlayerPrefs.SetInt("QualityDropDown", 2);
                PlayerPrefs.SetInt("Quality", 5);
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"), true);
                break;
            case 0:
                PlayerPrefs.SetInt("QualityDropDown", 0);
                PlayerPrefs.SetInt("Quality", 1);
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"), true);
                break;
        }
    }
    public void onchange()
    {
        if (j > 1)
        {
            AudioManager.instance.Play("DropdownSelect");
        }
        j++;
    }
}
