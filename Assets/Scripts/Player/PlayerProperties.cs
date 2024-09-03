using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    public Animator anim;
    float timeScaler;
    public static float timer;
    public static float arrowSpwnFactor;
    
    //For Planes
    public Transform planeLeft;
    public Transform planeRight;
    private Vector3 PLcurrentPos;
    private Vector3 PRcurrentPos;
    public Transform planeTop;
    private Vector3 PTcurrentPos;

    public Transform coinPrefab;

    //For GameOver
    public GameObject PSMove;
    public GameObject PSMagnet;
    public GameObject gameOverPanel;
    public GameObject BtnPanel;
    public GameObject medium;
    public GameObject large;
    public static int btnCount;
    public Transform blood;
    public static bool death;
    public static bool ghostSP;
    private bool red;

    public int SPMoveDis;
    public Transform SPmove;
    public Transform SPmagnet;
    string music;

    private bool ghostController = true;

    public static PlayerProperties Instance;
    private void Awake()
    {
        Instance = this;
        timer = 1;
    }

    // Use this for initialization
    void Start ()
    {
        ghostController = true;
        timeScaler = 50;
        arrowSpwnFactor = 2;
        coinStart();
        PSMove.SetActive(false);
        PSMagnet.SetActive(false);
        PTcurrentPos = planeTop.position;
        PLcurrentPos = planeLeft.position;
        PRcurrentPos = planeRight.position;
        //LowCurrentPos = lowPlane.position;
        btnCount = PlayerPrefs.GetInt("btnSize",1);
        btnPanelChoose();
        gameOverPanel.SetActive(false);
        death = false;
        ghostSP = false;
        red = true;
        if(PlayerPrefs.GetInt("CurrentModel", 0) == 0)
        {
            music = "AssassinDeath";
        }
        else if(PlayerPrefs.GetInt("CurrentModel", 0) == 1)
        {
            music = "KnightDeath";
        }
        else if(PlayerPrefs.GetInt("CurrentModel", 0) == 2)
        {
            music = "MutantDeath";
        }
	}
    #region btns
    public void btnPanelChoose()
    {
        if (btnCount == 0)
        {
            BtnPanel.SetActive(true);
            medium.SetActive(false);
            large.SetActive(false);
        }
        if (btnCount == 1)
        {
            medium.SetActive(true);
            BtnPanel.SetActive(false);
            large.SetActive(false);
        }
        if (btnCount == 2)
        {
            large.SetActive(true);
            BtnPanel.SetActive(false);
            medium.SetActive(false);
        }
    }
    public void btnPanelChoo()
    {
        if (btnCount == 0)
        {
            BtnPanel.SetActive(false);
        }
        if (btnCount == 1)
        {
            medium.SetActive(false);
        }
        if (btnCount == 2)
        {
            large.SetActive(false);
        }
    }
    #endregion

    // Update is called once per frame
    void Update ()
    {
        int j = 100;
        if(transform.position.z >= timeScaler && transform.position.z <= 1000)
        {
            Time.timeScale = 1+ transform.position.z / 4000;
            timer = Time.timeScale;
            timeScaler += 50;
            if(arrowSpwnFactor > 1.26f)
            {
                arrowSpwnFactor -= 0.15f;
            }
        }
        if(transform.position.z > SPMoveDis)
        {
            int spChoose = Random.Range(0, 2);
            if (spChoose == 0)
            {
                if (Spawner.singleLane == false)
                {
                    SPMoveDis += j;
                    int[] choices = { -4,-1, 1, 4 };
                    int tile = Random.Range(0, 4);
                    Instantiate(SPmove, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmove.rotation);
                }
                else
                {
                    Instantiate(SPmove, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmove.rotation);
                }
            }
            else if(spChoose == 1)
            {
                if (Spawner.singleLane == false)
                {
                    SPMoveDis += j;
                    int[] choices = { -4,-1, 1, 4 };
                    int tile = Random.Range(0, 4);
                    Instantiate(SPmagnet, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmagnet.rotation);
                }
                else
                {
                    Instantiate(SPmagnet, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmagnet.rotation);
                }
            }
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (ghostSP == false && death == false && MutantSP.mutantSP == false)
        {
            if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Hammer")
            {
                if (collision.gameObject.tag == "Hammer")
                {
                    CameraShake.shouldShake = true;
                    AudioManager.instance.Play("HammerHit");
                }
                AudioManager.instance.Pause("Main");
                AudioManager.instance.Play("Blood");
                AudioManager.instance.Play(music);
                PlayerMovement.speeder = 0;
                PlayerMovement1.speeder = 0;
                PlayerMovement2.speeder = 0;
                btnPanelChoo();
                PSMove.SetActive(false);
                PSMagnet.SetActive(false);
                death = true;
                if (red == true)
                {
                    Instantiate(blood, new Vector3(transform.position.x, 1, transform.position.z), blood.rotation);
                    red = false;
                }
                anim.SetBool("Run", false);
                anim.SetTrigger("death");
                PowerActivator.SPmovetrigger = false;
                PowerActivator.magnetic = false;
                StartCoroutine(afterdeath(3));
            }
        }
        else if(ghostSP == true && death == false)
        {
            if (collision.gameObject.tag == "Obstacles")
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }
            if (ghostController == true)
            {
                ghostController = false;
                StartCoroutine(ingorePhysics());
            }
        }
    }
    IEnumerator ingorePhysics()
    {
        yield return new WaitForSeconds(3);
        ghostSP = false;
        ghostController = true;
        red = true;
    }
    IEnumerator afterdeath(float wait)
    {
        yield return new WaitForSecondsRealtime(wait);
        if (GameBanner.noofPlay >= 5)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video");
                PlayerPrefs.SetInt("noofplay", 0);
            }
        }
        AudioManager.instance.Play("URDead");
        PauseExit.timescale = true;
        gameOverPanel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(death == false)
        {
            if (other.gameObject.tag == "GrndSpawn")
            {
                planeTop.position = new Vector3(PTcurrentPos.x, PTcurrentPos.y, PTcurrentPos.z + 19);
                PTcurrentPos = planeTop.position;
                planeLeft.position = new Vector3(PLcurrentPos.x, PLcurrentPos.y, PLcurrentPos.z + 20);
                PLcurrentPos = planeLeft.position;
                planeRight.position = new Vector3(PRcurrentPos.x, PRcurrentPos.y, PRcurrentPos.z + 20);
                PRcurrentPos = planeRight.position;
            }
            if(other.gameObject.tag == "Finish")
            {
                PlayerMovement.speeder = 0;
                PlayerMovement1.speeder = 0;
                AudioManager.instance.Stop("Main");
                AudioManager.instance.Play("Fall");
                btnPanelChoo();
                PSMove.SetActive(false);
                PSMagnet.SetActive(false);
                death = true;
                anim.SetBool("Run", false);
                anim.SetTrigger("Fall");
                PowerActivator.SPmovetrigger = false;
                PowerActivator.magnetic = false;
                PowerActivator.SPmovetrigger = false;
                PowerActivator.magnetic = false;
                StartCoroutine(afterdeath(2));
            }
        }
    }
    public void spawner()
    {
        if (transform.position.z <= 150)
        {
            if (Spawner.singleLane == false)
            {
                int[] choices = { -4, -1, 1, 4, 4, -1, 1, -4 };
                int tile = Random.Range(0, 4);
                int tile2 = Random.Range(4, 8);
                Instantiate(coinPrefab, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, 0)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile2], 1, Spawner.spawnDistance - Random.Range(0, 10)), coinPrefab.rotation);
            }
            else
            {
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, 0)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(0, 10)), coinPrefab.rotation);
                Spawner.singleLane = false;
            }
        }
        else if(transform.position.z > 150 && transform.position.z <= 300)
        {
            if (Spawner.singleLane == false)
            {
                int[] choices = { -4, -1, 1, 4, 4, -1, 1, -4, 4, -1, 1, -4 };
                int tile = Random.Range(0, 4);
                int tile2 = Random.Range(4, 8);
                int tile3 = Random.Range(8, 12);
                Instantiate(coinPrefab, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, -3)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile2], 1, Spawner.spawnDistance - Random.Range(-3, 3)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile3], 1, Spawner.spawnDistance - Random.Range(3, 10)), coinPrefab.rotation);
            }
            else
            {
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, 0)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(0, 10)), coinPrefab.rotation);
                Spawner.singleLane = false;
            }
        }
        else if(transform.position.z > 300)
        {
            if (Spawner.singleLane == false)
            {
                int[] choices = { -4, -1, 1, 4, 4, -1, 1, -4, -4, -1, 1, 4, 4, -1, 1, -4 };
                int tile = Random.Range(0, 4);
                int tile2 = Random.Range(4, 8);
                int tile3 = Random.Range(8, 12);
                int tile4 = Random.Range(12,16);
                Instantiate(coinPrefab, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, -4)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile2], 1, Spawner.spawnDistance - Random.Range(-4, 1)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile3], 1, Spawner.spawnDistance - Random.Range(1, 6)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(choices[tile4], 1, Spawner.spawnDistance - Random.Range(6, 10)), coinPrefab.rotation);
            }
            else
            {
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, -4)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-4, 1)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(1, 6)), coinPrefab.rotation);
                Instantiate(coinPrefab, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(6, 10)), coinPrefab.rotation);
                Spawner.singleLane = false;
            }
        }
    }
    void coinStart()
    {
        int[] choices = { -4,-1, 1, 4, 4,-1, 1, -4 };
        int tile = Random.Range(0, 4);
        int tile2 = Random.Range(4, 8);
        Instantiate(coinPrefab, new Vector3(choices[tile], 1, 30.2f - Random.Range(-9, 0)), coinPrefab.rotation);
        Instantiate(coinPrefab, new Vector3(choices[tile2], 1, 30.2f - Random.Range(0, 10)), coinPrefab.rotation);
    }
}
