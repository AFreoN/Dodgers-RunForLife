using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightSP : MonoBehaviour
{
    public Image filler;
    public Transform aggrandize;
    public GameObject can;
    public float PowerTime = 20;
    public float duration=10;
    private float startTime;
    public static bool doubleCoin;
    public Button powerBtn;
    private bool decrease;

	void Start ()
    {
        doubleCoin = false;
        decrease = false;
        powerBtn.interactable = false;
        startTime = Time.time;
	}
	
	void Update ()
    {
        if (PauseExit.timescale == false && PlayerProperties.death == false && filler.fillAmount <= 1 && decrease == false)
        {
            float fill =startTime+ PowerTime - Time.time;
            filler.fillAmount = 1 - fill/PowerTime;
            if (filler.fillAmount == 1)
            {
                powerBtn.interactable = true;
                powerBtn.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            }
        }
        if(decrease == true && PlayerProperties.death == false && PauseExit.timescale == false && filler.fillAmount != 0)
        {
            float fillDown = startTime + duration - Time.time;
            filler.fillAmount = fillDown / duration;
        }
	}
    public void powerAction()
    {
        doubleCoin = true;
        AudioManager.instance.Play("KnightSP");
        Instantiate(aggrandize, can.transform, false);
        startTime = Time.time;
        decrease = true;
        powerBtn.interactable = false;
        powerBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        StartCoroutine(spActive());
    }

    IEnumerator spActive()
    {
        yield return new WaitForSeconds(duration);
        AudioManager.instance.Play("PowerDown");
        doubleCoin = false;
        startTime = Time.time;
        decrease = false;
    }
}
