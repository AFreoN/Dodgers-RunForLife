using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MutantSP : MonoBehaviour
{
    public GameObject destroyPS;
    public GameObject can;
    public Transform destroyImg;
    public Button powerBtn;
    public Image filler;
    public float PowerTime;
    public float duration;
    private float startTime;
    public static bool mutantSP;
    private bool decrease;
    private GameObject pscontroller;

    void Start ()
    {
        mutantSP = false;
        decrease = false;
        powerBtn.interactable = false;
        startTime = Time.time;
    }

    void Update()
    {
        if (PauseExit.timescale == false && PlayerProperties.death == false && filler.fillAmount <= 1 && decrease == false)
        {
            float fill = startTime + PowerTime - Time.time;
            filler.fillAmount = 1 - fill / PowerTime;
            if (filler.fillAmount == 1)
            {
                powerBtn.interactable = true;
                powerBtn.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
            }
        }
        if (decrease == true && PlayerProperties.death == false && PauseExit.timescale == false && filler.fillAmount != 0)
        {
            float fillDown = startTime + duration - Time.time;
            filler.fillAmount = fillDown / duration;
        }
    }
    public void powerAction()
    {
        mutantSP = true;
        AudioManager.instance.Play("MutantSP");
        startTime = Time.time;
        decrease = true;
        Instantiate(destroyImg, can.transform, false);
        powerBtn.interactable = false;
        powerBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        StartCoroutine(offMutantSP());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (mutantSP == true)
        {
            if (collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "Obstacles")
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
                pscontroller = Instantiate(destroyPS, pos, Quaternion.identity) as GameObject;
                Destroy(pscontroller, 1);
                collision.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator offMutantSP()
    {
        yield return new WaitForSeconds(duration);
        AudioManager.instance.Play("PowerDown");
        mutantSP = false;
        startTime = Time.time;
        decrease = false;
    }
}
