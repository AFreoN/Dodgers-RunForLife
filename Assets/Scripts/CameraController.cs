using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //For Camera
    private Vector3 offset;
    public Transform[] player;
    public float transitionSpeed;
    private int modelnum;

    //For BackGrnd
    public Transform backGrnd;
    Vector3 backOffset;
    public GameObject startAnimImg;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    // Use this for initialization
    void Start ()
    {
        AudioManager.instance.Play("Main");
        LowPlane.follow = true;
        startAnimImg.SetActive(true);
        StartCoroutine(anim());
        modelnum = PlayerPrefs.GetInt("CurrentModel", 0);
        offset = player[modelnum].position - transform.position;
        backOffset = backGrnd.position - player[modelnum].position;
	}
    IEnumerator anim()
    {
        yield return new WaitForSeconds(1);
        startAnimImg.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void FixedUpdate()
    {
        if (LowPlane.follow == true && CameraShake.shouldShake == false)
        {
            Vector3 currentpos = player[modelnum].position - offset;
            transform.position = Vector3.Lerp(transform.position, currentpos, transitionSpeed);

            Vector3 backCurrentpos = player[modelnum].position + backOffset;
            backGrnd.position = Vector3.Lerp(backGrnd.position, new Vector3(0, 4, backCurrentpos.z), 100);
        }
    }
}
