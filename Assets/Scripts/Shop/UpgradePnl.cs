using UnityEngine;
using UnityEngine.UI;

public class UpgradePnl : MonoBehaviour
{
    public GameObject[] moveImg;
    public Button moveUp;
    public Text moveUpAmount;
    public GameObject dd;
    private int status;
    private int[] moveUPcost = { 400, 250, 150, 100, 50 };

    public GameObject[] magnetImg;
    public Button magnetBtn;
    public Text magnetUpAmount;
    public GameObject mm;
    private int magnetStatus;
    private int[] magnetUPcost = { 450, 300, 200, 125, 60 };

    public GameObject notEnoughCoins;

	// Use this for initialization
	void Start ()
    {
        dd.SetActive(false);
        mm.SetActive(false);
        notEnoughCoins.SetActive(false);
        status = PlayerPrefs.GetInt("SPMove", 5);
        magnetStatus = PlayerPrefs.GetInt("SPMagnet", 5);
        for(int i=0;i<status;i++)
        {
            moveImg[i].SetActive(false);
        }
        for(int j=0;j<magnetStatus;j++)
        {
            magnetImg[j].SetActive(false);
        }
	}
    #region moveSP
    public void spmoveplus()
    {
        AudioManager.instance.Play("Upgrade");
        if(status == 0)
        {
            return;
        }
        moveUpAmount.text = moveUPcost[status-1].ToString();
        dd.SetActive(true);
    }
    public void moveupgradeBtn()
    {
        AudioManager.instance.Play("Upgraded");
        switch (status)
        {
            case 5:
                if(PlayerPrefs.GetInt("TotalCoins")>moveUPcost[status-1])
                {
                    moveImg[4].SetActive(true);
                    PlayerPrefs.SetInt("SPMove", 4);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - moveUPcost[status-1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("TotalCoins") > moveUPcost[status - 1])
                {
                    moveImg[3].SetActive(true);
                    PlayerPrefs.SetInt("SPMove", 3);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - moveUPcost[status - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("TotalCoins") > moveUPcost[status - 1])
                {
                    moveImg[2].SetActive(true);
                    PlayerPrefs.SetInt("SPMove", 2);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - moveUPcost[status - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("TotalCoins") > moveUPcost[status - 1])
                {
                    moveImg[1].SetActive(true);
                    PlayerPrefs.SetInt("SPMove", 1);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - moveUPcost[status - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("TotalCoins") > moveUPcost[status - 1])
                {
                    moveImg[0].SetActive(true);
                    PlayerPrefs.SetInt("SPMove", 0);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - moveUPcost[status - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            default:
                moveUp.interactable = false;
                break;
        }
        status = PlayerPrefs.GetInt("SPMove");
        dd.SetActive(false);
    }
    public void closeMoveUp()
    {
        AudioManager.instance.Play("Back");
        dd.SetActive(false);
    }
    #endregion
    #region Magnet
    public void magnetUPopen()
    {
        AudioManager.instance.Play("Upgrade");
        magnetUpAmount.text = magnetUPcost[magnetStatus-1].ToString();
        mm.SetActive(true);
    }
    public void magnetupgradeBtn()
    {
        AudioManager.instance.Play("Upgraded");
        if (magnetStatus == 0)
        {
            return;
        }
        switch (magnetStatus)
        {
            case 5:
                if (PlayerPrefs.GetInt("TotalCoins") > magnetUPcost[magnetStatus-1])
                {
                    magnetImg[4].SetActive(true);
                    PlayerPrefs.SetInt("SPMagnet", 4);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - magnetUPcost[magnetStatus - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("TotalCoins") > magnetUPcost[magnetStatus - 1])
                {
                    magnetImg[3].SetActive(true);
                    PlayerPrefs.SetInt("SPMagnet", 3);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - magnetUPcost[magnetStatus - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("TotalCoins") > magnetUPcost[magnetStatus - 1])
                {
                    magnetImg[2].SetActive(true);
                    PlayerPrefs.SetInt("SPMagnet", 2);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - magnetUPcost[magnetStatus - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("TotalCoins") > magnetUPcost[magnetStatus - 1])
                {
                    magnetImg[1].SetActive(true);
                    PlayerPrefs.SetInt("SPMagnet", 1);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - magnetUPcost[magnetStatus - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("TotalCoins") > magnetUPcost[magnetStatus - 1])
                {
                    magnetImg[0].SetActive(true);
                    PlayerPrefs.SetInt("SPMagnet", 0);
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - magnetUPcost[magnetStatus - 1]);
                }
                else
                {
                    notEnoughCoins.SetActive(true);
                }
                break;
            default:
                magnetBtn.interactable = false;
                break;
        }
        magnetStatus = PlayerPrefs.GetInt("SPMagnet");
        mm.SetActive(false);
    }
    public void closeMagnetUp()
    {
        AudioManager.instance.Play("Back");
        mm.SetActive(false);
    }
    #endregion
    public void closeNotEnough()
    {
        AudioManager.instance.Play("Back");
        notEnoughCoins.SetActive(false);
    }
}
