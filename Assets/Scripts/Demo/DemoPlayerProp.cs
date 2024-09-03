using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoPlayerProp : MonoBehaviour
{
    public Animator anim;

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
    public Transform blood;
    public static bool death;
    public static bool ghostSP;
    private bool red;

    public int SPMoveDis;
    public Transform SPmove;
    public Transform SPmagnet;
    string music;

    private bool ghostController = true;

    public static DemoPlayerProp Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        ghostController = true;
        PSMove.SetActive(false);
        PSMagnet.SetActive(false);
        PTcurrentPos = planeTop.position;
        PLcurrentPos = planeLeft.position;
        PRcurrentPos = planeRight.position;
        //LowCurrentPos = lowPlane.position;
        death = false;
        ghostSP = false;
        red = true;
        if (PlayerPrefs.GetInt("CurrentModel", 0) == 0)
        {
            music = "AssassinDeath";
        }
        else if (PlayerPrefs.GetInt("CurrentModel", 0) == 1)
        {
            music = "KnightDeath";
        }
        else if (PlayerPrefs.GetInt("CurrentModel", 0) == 2)
        {
            music = "MutantDeath";
        }
    }

    // Update is called once per frame
    void Update()
    {
        int j = 100;
        if (transform.position.z > SPMoveDis)
        {
            int spChoose = Random.Range(0, 2);
            if (spChoose == 0)
            {
                if (Spawner.singleLane == false)
                {
                    SPMoveDis += j;
                    int[] choices = { -4, 1, 4 };
                    int tile = Random.Range(0, 3);
                    Instantiate(SPmove, new Vector3(choices[tile], 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmove.rotation);
                }
                else
                {
                    Instantiate(SPmove, new Vector3(0, 1, Spawner.spawnDistance - Random.Range(-9, 10)), SPmove.rotation);
                }
            }
            else if (spChoose == 1)
            {
                if (Spawner.singleLane == false)
                {
                    SPMoveDis += j;
                    int[] choices = { -4, 1, 4 };
                    int tile = Random.Range(0, 3);
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
        else if (ghostSP == true && death == false)
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
        AudioManager.instance.Play("URDead");
        PauseExit.timescale = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (death == false)
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
            if (other.gameObject.tag == "Finish")
            {
                PlayerMovement.speeder = 0;
                PlayerMovement1.speeder = 0;
                AudioManager.instance.Stop("Main");
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

}
