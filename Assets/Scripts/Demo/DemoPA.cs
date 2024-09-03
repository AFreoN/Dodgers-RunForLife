using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoPA : MonoBehaviour
{
    public static DemoPA Instance;

    public GameObject SPmovePS;
    public static bool SPmovetrigger = false;
    private float[] movepowerTime = { 8, 7, 6.5f, 6, 5.5f, 5 };
    public Image moveSideHeader;
    private float moveStartTime;

    public GameObject SPMagnetPS;
    public static bool magnetic = false;
    private float[] magnetPowerTime = { 20, 18, 16, 14, 12, 10 };
    public Image magnetHeader;
    private float magnetStartTime;

    public GameObject SPGhostPS;
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
        SPmovePS.SetActive(false);
        SPMagnetPS.SetActive(false);
        SPGhostPS.SetActive(false);
        moveSideHeader.fillAmount = 0;
        magnetHeader.fillAmount = 0;
        GhostHeader.fillAmount = 0;
        music = "Mutant";
    }
    private void Update()
    {
        if (SPmovetrigger == true)
        {
            float fillMove = (Time.time - moveStartTime) / movepowerTime[PlayerPrefs.GetInt("SPMove")];
            moveSideHeader.fillAmount = 1 - fillMove;
        }
        else
        {
            moveSideHeader.fillAmount = 0;
        }
        if (magnetic == false)
        {
            magnetHeader.fillAmount = 0;
        }
        else
        {
            float fillMagnet = (Time.time - magnetStartTime) / magnetPowerTime[PlayerPrefs.GetInt("SPMagnet")];
            magnetHeader.fillAmount = 1 - fillMagnet;
        }
        if (PlayerProperties.ghostSP == true && PlayerProperties.death == false)
        {
            if (allowGhost == true)
            {
                allowGhost = false;
                GhostStartTime = Time.time;
                SPGhostPS.SetActive(true);
                StartCoroutine(GhostPowerIP());
            }
            float fillGhost = (Time.time - GhostStartTime) / 3;
            GhostHeader.fillAmount = 1 - fillGhost;
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
        SPGhostPS.SetActive(false);
        allowGhost = true;
        AudioManager.instance.Play("PowerDown");
    }
    public void moveSide()
    {
        AudioManager.instance.Play(music + "Sprint");
        SPmovetrigger = true;
        SPmovePS.SetActive(true);
        moveStartTime = Time.time;
        StartCoroutine(powerUp());
    }
    IEnumerator powerUp()
    {
        yield return new WaitForSeconds(movepowerTime[PlayerPrefs.GetInt("SPMove")]);
        SPmovePS.SetActive(false);
        SPmovetrigger = false;
        AudioManager.instance.Play("PowerDown");
    }
    public void magnet()
    {
        AudioManager.instance.Play(music + "Magneto");
        magnetic = true;
        SPMagnetPS.SetActive(true);
        magnetStartTime = Time.time;
        StartCoroutine(activate());
    }
    IEnumerator activate()
    {
        yield return new WaitForSeconds(magnetPowerTime[PlayerPrefs.GetInt("SPMagnet")]);
        SPMagnetPS.SetActive(false);
        magnetic = false;
        AudioManager.instance.Play("PowerDown");
    }
}
