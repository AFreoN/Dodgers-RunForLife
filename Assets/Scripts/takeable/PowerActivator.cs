using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerActivator : MonoBehaviour {
    public static PowerActivator Instance;
    private int modelNum;
    public GameObject canvs;
    public GameObject[] SPmovePS;
    public static bool SPmovetrigger=false;
    private float[] movepowerTime= { 8,7,6.5f,6,5.5f,5};
    public Image moveSideHeader;
    private float moveStartTime;
    public Transform sprinter;

    public GameObject[] SPMagnetPS;
    public static bool magnetic = false;
    private float[] magnetPowerTime = { 20, 18, 16, 14, 12, 10 };
    public Image magnetHeader;
    private float magnetStartTime;
    public Transform Magneto;

    public GameObject[] SPGhostPS;
    public Image GhostHeader;
    private bool allowGhost = true;
    private float GhostStartTime;
    string music;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        modelNum = PlayerPrefs.GetInt("CurrentModel", 0);
        SPmovePS[modelNum].SetActive(false);
        SPMagnetPS[modelNum].SetActive(false);
        SPGhostPS[modelNum].SetActive(false);
        moveSideHeader.fillAmount = 0;
        magnetHeader.fillAmount = 0;
        GhostHeader.fillAmount = 0;
        if (modelNum == 0)
        {
            music = "Assassin";
        }
        else if (modelNum == 1)
        {
            music = "Knight";
        }
        else if (modelNum == 2)
        {
            music = "Mutant";
        }
    }
    private void Update()
    {
        if(SPmovetrigger == true)
        {
            float fillMove = (Time.time - moveStartTime) / movepowerTime[PlayerPrefs.GetInt("SPMove")];
            moveSideHeader.fillAmount = 1- fillMove;
        }
        else
        {
            moveSideHeader.fillAmount = 0;
        }
        if(magnetic == false)
        {
            magnetHeader.fillAmount = 0;
        }
        else
        {
            float fillMagnet = (Time.time - magnetStartTime) / magnetPowerTime[PlayerPrefs.GetInt("SPMagnet")];
            magnetHeader.fillAmount =  1-fillMagnet;
        }
        if (PlayerProperties.ghostSP == true && PlayerProperties.death == false)
        {
            if(allowGhost == true)
            {
                allowGhost = false;
                GhostStartTime = Time.time;
                SPGhostPS[modelNum].SetActive(true);
                StartCoroutine(GhostPowerIP());
            }
            float fillGhost = (Time.time - GhostStartTime)/3;
            GhostHeader.fillAmount =1- fillGhost;
        }
        else
        {
            allowGhost = true;
            GhostHeader.fillAmount = 0;
        }
    }
    IEnumerator GhostPowerIP()
    {
        yield return new WaitForSeconds(3.1f);
        SPGhostPS[modelNum].SetActive(false);
        allowGhost = true;
        AudioManager.instance.Play("PowerDown");
    }
    public void moveSide()
    {
        AudioManager.instance.Play(music + "Sprint");
        Instantiate(sprinter, canvs.transform, false);
        SPmovetrigger = true;
        SPmovePS[modelNum].SetActive(true);
        moveStartTime = Time.time;
        StartCoroutine(powerUp());
    }
    IEnumerator powerUp()
    {
        yield return new WaitForSeconds(movepowerTime[PlayerPrefs.GetInt("SPMove")]);
        SPmovePS[modelNum].SetActive(false);
        SPmovetrigger = false;
        AudioManager.instance.Play("PowerDown");
    }
    public void magnet()
    {
        AudioManager.instance.Play(music+"Magneto");
        Instantiate(Magneto, canvs.transform, false);
        magnetic = true;
        SPMagnetPS[modelNum].SetActive(true);
        magnetStartTime = Time.time;
        StartCoroutine(activate());
    }
    IEnumerator activate()
    {
        yield return new WaitForSeconds(magnetPowerTime[PlayerPrefs.GetInt("SPMagnet")]);
        SPMagnetPS[modelNum].SetActive(false);
        magnetic = false;
        AudioManager.instance.Play("PowerDown");
    }
}
