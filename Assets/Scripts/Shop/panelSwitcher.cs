using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelSwitcher : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject characterPanel;
    public GameObject startAnim;

	void Start ()
    {
        startAnim.SetActive(true);
        AudioManager.instance.Play("MainTheme");
        characterPanel.SetActive(false);
        upgradePanel.SetActive(true);
	}

    public void upgradePanelBtn()
    {
        characterPanel.SetActive(false);
        upgradePanel.SetActive(true);
        AudioManager.instance.Play("Click");
    }
    public void characterPanelBtn()
    {
        upgradePanel.SetActive(false);
        characterPanel.SetActive(true);
        AudioManager.instance.Play("Click");
    }
}
