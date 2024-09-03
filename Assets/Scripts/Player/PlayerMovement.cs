using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Animator anim;
    private Quaternion angle;
    public CapsuleCollider playercollider;
    private Vector3 colliderdimension;

    private float height;
    private bool jumpcount = true;
    private float jumptime = -0.65f;

    private float speed;
    public static float speeder;
    public float jumpspeed;
    public float sideforce;
    private int rotAngle = 50;
    private float vcheck;

    float dirx;
    float diry;
    private bool angler = true;
    public static bool right;

    private float jumpcontrol;
    private float gravity;

    public static bool jumpda=false;

    private void Awake()
    {
        playercollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        angle = transform.rotation;
    }

    void Start ()
    {
        rb.velocity = Vector3.forward * speed;
        colliderdimension = playercollider.center;
        height = playercollider.height;
        vcheck = rb.velocity.z;
        gravity = jumpspeed /1.7f;
        jumptime = Time.time-0.65f;
        speeder = 5;
        speed = speeder;
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = speeder;
        dirx = CrossPlatformInputManager.GetAxis("Horizontal");
        diry = CrossPlatformInputManager.GetAxis("Vertical");
        if(PowerActivator.SPmovetrigger == true)
        {
            sideforce = 400;
            rotAngle = 50;
        }
        else
        {
            sideforce = 200;
            rotAngle = 25;
        }
        rb.velocity = new Vector3(dirx * sideforce *Time.deltaTime+ diry*sideforce * Time.deltaTime,-gravity *Time.deltaTime + jumpcontrol * Time.deltaTime, speed);
        if (dirx != 0 && angler == true)
        {
            //transform.Rotate(0,-rotAngle,0);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, transform.rotation.y, 0), Quaternion.Euler(0, -rotAngle * 2, 0), 0.5f);
            angler = false;
        }
        else if (diry != 0 && angler == true)
        {
            //transform.Rotate(0, rotAngle, 0);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, transform.rotation.y, 0), Quaternion.Euler(0, rotAngle * 2, 0), 0.5f);
            angler = false;
        }
        else if (dirx == 0 && diry == 0)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, transform.rotation.y, 0), Quaternion.Euler(0, 0, 0), 0.5f);
            angler = true;
        }
        if (rb.velocity.z < vcheck)
        {
            rb.velocity = Vector3.forward * speed;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time > jumptime + 0.65f)
            {
                jumptime = Time.time;
                if (jumpcount == true)
                {
                    anim.SetTrigger("jump");
                    jumpcontrol = jumpspeed;
                    playercollider.height = 1.3f;
                    playercollider.center = new Vector3(colliderdimension.x, 1.5f, colliderdimension.z);
                    jumpcount = false;
                    StartCoroutine(jumpcollider(0.45f));
                }
            }
        }
        if(jumpda == true)
        {
            jumpda = false;
                if (jumpcount == true)
                {
                    anim.SetTrigger("jump");
                    jumpcontrol = jumpspeed;
                    playercollider.height = 1.3f;
                    playercollider.center = new Vector3(colliderdimension.x, 1.5f, colliderdimension.z);
                    jumpcount = false;
                    StartCoroutine(jumpcollider(0.5f));
                }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 25, 0);
            rb.velocity = new Vector3 (sideforce, 0, speed);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            transform.rotation = angle;
            rb.velocity = new Vector3(0, 0, speed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -25, 0);
            rb.velocity = new Vector3(-sideforce, 0, speed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = angle;
            rb.velocity = new Vector3(0, 0, speed);
        }

    }
    private IEnumerator jumpcollider(float wait)
    {
        yield return new WaitForSeconds(wait);
        playercollider.center = colliderdimension;
        playercollider.height = height;
        jumpcontrol = 0;
        jumpcount = true;
    }

}
