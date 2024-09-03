using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CharacterSwap : MonoBehaviour
{
    public GameObject[] characters;
    public Button rightBtn;
    public Button leftBtn;
    private int charNum;
    private int currentChar;
    public GameObject notEnoughCoins;
    public GameObject doyouWant;
    public Text charCost;
    public static int ShowModel;
    public GameObject[] specialPowerShow;
    private bool knightSPImg = true;
    private bool mutantSPImg = true;
    public GameObject praisePS;

    [System.Serializable]
    public class charactersData
    {
        public string charName;
        public bool bought;
        public GameObject Amount;
        public GameObject selectButton;
        public Button selectBtn;
        public GameObject buyButton;
        public Text select;
    }
    public List<charactersData> charData;

	void Start ()
    {
        //playerdatasStart
        PlayerPrefs.GetInt("Knight", 0);
        PlayerPrefs.GetInt("Mutant", 0);
        //playerdatsEnd
        notEnoughCoins.SetActive(false);
        praisePS.SetActive(false);
        doyouWant.SetActive(false);
        for(int i=0; i<specialPowerShow.Length;i++)
        {
            specialPowerShow[i].SetActive(false);
        }
        charNum = PlayerPrefs.GetInt("Model", 0);
        currentChar = PlayerPrefs.GetInt("CurrentModel", 0);
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        characters[charNum].SetActive(true);
        if (charNum == characters.Length-1)
        {
            rightBtn.interactable = false;
        }
        if (charNum == 0)
        {
            leftBtn.interactable = false;
        }
        charDatas();
    }
    private void Update()
    {
        if (charNum == characters.Length - 1)
        {
            rightBtn.interactable = false;
        }
        else
        {
            rightBtn.interactable = true;
        }
        if (charNum == 0)
        {
            leftBtn.interactable = false;
        }
        else
        {
            leftBtn.interactable = true;
        }
    }
    #region Swapping
    public void swapRight()
    {
        AudioManager.instance.Play("Swap");
        for(int i=0;i<characters.Length;i++)
        {
            characters[i].SetActive(false);
        }
        charNum++;
        PlayerPrefs.SetInt("Model", charNum);
        charDatas();
        characters[charNum].SetActive(true);
        if (charNum == characters.Length -1)
        {
            rightBtn.interactable = false;
        }
        if(charNum != 0)
        {
            PlayerPrefs.SetInt("showModel", charNum - 1);
        }
    }
    public void swapLeft()
    {
        AudioManager.instance.Play("Swap");
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        charNum--;
        PlayerPrefs.SetInt("Model", charNum);
        charDatas();
        characters[charNum].SetActive(true);
        if (charNum == 0)
        {
            leftBtn.interactable = false;
        }
        if (charNum != 0)
        {
            PlayerPrefs.SetInt("showModel", charNum - 1);
        }
    }
    #endregion
    public void iKnightBtn()
    {
        AudioManager.instance.Play("Special");
        if(knightSPImg == true)
        {
            specialPowerShow[charNum - 1].SetActive(true);
            knightSPImg = false;
        }
        else if(knightSPImg == false)
        {
            specialPowerShow[charNum - 1].SetActive(false);
            knightSPImg = true;
        }
    }
    public void imutantBtn()
    {
        AudioManager.instance.Play("Special");
        if (mutantSPImg == true)
        {
            specialPowerShow[charNum - 1].SetActive(true);
            mutantSPImg = false;
        }
        else if (mutantSPImg == false)
        {
            specialPowerShow[charNum - 1].SetActive(false);
            mutantSPImg = true;
        }
    }

    public void setBuyPanel()
    {
        AudioManager.instance.Play("Buy");
        doyouWant.SetActive(true);
        switch(charNum)
        {
            case 1:
                charCost.text = "1000";
                break;
            case 2:
                charCost.text = "5000";
                break;
        }
    }
    public void closeBuyPanel()
    {
        AudioManager.instance.Play("Back");
        doyouWant.SetActive(false);
    }
    public void BuyBtn()
    {
        switch (charNum)
        {
            case 1:
                if (PlayerPrefs.GetInt("TotalCoins") >= 1000)
                {
                    praisePS.SetActive(true);
                    PlayerPrefs.SetInt("CurrentModel", 1);
                    currentChar = PlayerPrefs.GetInt("CurrentModel");
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 1000);
                    PlayerPrefs.SetInt("Knight", 1);
                    AudioManager.instance.Play("Buyed");
                    charDatas();
                    doyouWant.SetActive(false);
                }
                else
                {
                    doyouWant.SetActive(false);
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("TotalCoins") >= 5000)
                {
                    praisePS.SetActive(true);
                    Instantiate(praisePS, new Vector3(-267, -26, -37), Quaternion.identity);
                    PlayerPrefs.SetInt("CurrentModel", 2);
                    currentChar = PlayerPrefs.GetInt("CurrentModel");
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 5000);
                    PlayerPrefs.SetInt("Mutant", 1);
                    AudioManager.instance.Play("Buyed");
                    charDatas();
                    doyouWant.SetActive(false);
                }
                else
                {
                    doyouWant.SetActive(false);
                    notEnoughCoins.SetActive(true);
                }
                break;

        }
    }
    public void closeNotEnoughCoins()
    {
        AudioManager.instance.Play("Back");
        notEnoughCoins.SetActive(false);
    }
    public void selectBtn()
    {
        AudioManager.instance.Play("Select");
        currentChar = charNum;
        PlayerPrefs.SetInt("CurrentModel", currentChar);
        charDatas();
    }
    public void previewBtn()
    {
        SceneManager.LoadScene(4,LoadSceneMode.Additive);
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            g.SetActive(false);
        }
    }
    private void charDatas()
    {
        switch(charNum)
        {
            case 1:
                charData[charNum].bought = PlayerPrefs.GetInt("Knight") == 0 ? false : true;
                if (charData[charNum].bought == true)
                {
                    charData[charNum].selectButton.SetActive(true);
                    charData[charNum].buyButton.SetActive(false);
                    charData[charNum].Amount.SetActive(false);
                    if (currentChar == charNum)
                    {
                        charData[charNum].selectBtn.interactable = false;
                        charData[charNum].select.text = "Selected";
                    }
                    else
                    {
                        charData[charNum].selectBtn.interactable = true ;
                        charData[charNum].select.text = "Select";
                    }
                }
                else
                {
                    charData[charNum].Amount.SetActive(true);
                    charData[charNum].selectButton.SetActive(false);
                    charData[charNum].buyButton.SetActive(true);
                }
                break;
            case 2:
                charData[charNum].bought = PlayerPrefs.GetInt("Mutant") == 0 ? false : true;
                if (charData[charNum].bought == true)
                {
                    charData[charNum].selectButton.SetActive(true);
                    charData[charNum].buyButton.SetActive(false);
                    charData[charNum].Amount.SetActive(false);
                    if (currentChar == charNum)
                    {
                        charData[charNum].selectBtn.interactable = false;
                        charData[charNum].select.text = "Selected";
                    }
                    else
                    {
                        charData[charNum].selectBtn.interactable = true;
                        charData[charNum].select.text = "Select";
                    }
                }
                else
                {
                    charData[charNum].Amount.SetActive(true);
                    charData[charNum].selectButton.SetActive(false);
                    charData[charNum].buyButton.SetActive(true);
                }
                break;
            case 0:
                charData[charNum].selectButton.SetActive(true);
                charData[charNum].buyButton.SetActive(false);
                charData[charNum].Amount.SetActive(false);
                if (currentChar == charNum)
                {
                    charData[charNum].selectBtn.interactable = false;
                    charData[charNum].select.text = "Selected";
                }
                else
                {
                    charData[charNum].selectBtn.interactable = true;
                    charData[charNum].select.text = "Select";
                }
                break;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Model", currentChar);
    }
}
