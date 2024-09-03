using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingerMovement : MonoBehaviour
{

    public float rotspeed;
    public Transform swingend;
    private bool trigger = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseExit.timescale == false)
        {
            if (trigger == true)
            {
                transform.RotateAround(swingend.position, Vector3.forward, rotspeed);
                if (transform.eulerAngles.x > 30 && transform.eulerAngles.x < 330)
                {
                    trigger = false;
                }
            }
            if (trigger == false)
            {
                transform.RotateAround(swingend.position, Vector3.back, rotspeed);
                if (transform.eulerAngles.z < 330 && transform.eulerAngles.z > 30)
                {
                    trigger = true;
                }
            }
        }
        else if (PauseExit.timescale == true)
        {
            Time.timeScale = 0;
        }
    }
}
