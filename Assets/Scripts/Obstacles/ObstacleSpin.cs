using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    Rigidbody obj;
    private bool right = true;
    public float movespeed;
    public float rotatespeed;
    AudioSource source;
    bool control;

    private void Awake()
    {
        obj = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        control = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PauseExit.timescale == false)
        {
            transform.Rotate(0, 0, rotatespeed);
            if (right == true)
            {
                obj.velocity = Vector3.right * movespeed;
                if (transform.position.x > 3.7)
                {
                    right = false;
                }

            }
            if (right == false)
            {
                obj.velocity = Vector3.left * movespeed;
                if (transform.position.x < -3.7)
                {
                    right = true;
                }
            }
            if(PlayerProperties.death == true && control == true)
            {
                source.Stop();
                control = false;
            }
            else if(PlayerProperties.death == false && control == false)
            {
                source.Play();
                control = true;
            }

        }
	}
}
