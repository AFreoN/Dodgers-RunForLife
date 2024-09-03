using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DemoHammer : MonoBehaviour
{
    public float rotspeed;
    public Transform hamend;
    private bool trigger = true;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SequenceofDemo.timeControl == false)
        {
            if (trigger == true)
            {
                transform.RotateAround(hamend.position, Vector3.forward, rotspeed);
                if (transform.eulerAngles.z > 30 && transform.eulerAngles.z < 330)
                {
                    trigger = false;
                }
            }
            if (trigger == false)
            {
                transform.RotateAround(hamend.position, Vector3.back, rotspeed);
                if (transform.eulerAngles.z < 330 && transform.eulerAngles.z > 30)
                {
                    trigger = true;
                }
            }
            if (transform.eulerAngles.z < 0.1f && transform.eulerAngles.z > -0.1f)
            {
                if (source.isPlaying == false && PlayerProperties.death == false)
                {
                    source.Play();
                }
            }
        }
    }
}
