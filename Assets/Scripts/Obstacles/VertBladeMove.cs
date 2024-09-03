using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertBladeMove : MonoBehaviour
{
    Rigidbody obj;
    AudioSource source;
    private bool top = true;
    public float movespeed;
    public float rotatespeed;
    private float spawndis;
    bool control;

    private void Awake()
    {
        obj = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        spawndis = Spawner.vertbla - 20.2f;
        control = true;
    }

    void Update()
    {
        if (PauseExit.timescale == false)
        {
            transform.Rotate(0, 0, rotatespeed);
            if (top == true)
            {
                obj.velocity = Vector3.forward * movespeed * Time.deltaTime;
                if (transform.position.z > spawndis + 8.5f)
                {
                    top = false;
                }
            }
            if (top == false)
            {
                obj.velocity = Vector3.back * movespeed * Time.deltaTime;
                if (transform.position.z < spawndis - 8.5f)
                {
                    top = true;
                }
            }
            if (PlayerProperties.death == true && control == true)
            {
                source.Stop();
                control = false;
            }
            else if (PlayerProperties.death == false && control == false)
            {
                source.Play();
                control = true;
            }
        }
    }
}
