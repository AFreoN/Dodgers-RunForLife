using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoArrowSpwn : MonoBehaviour
{
    public Rigidbody arrowPrefab;
    public Transform spawnend;
    private float timetospawn;
    public float spawnrate;
    public float arrowSpeed;

    // Use this for initialization
    void Start()
    {
        timetospawn = Time.time + spawnrate;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > timetospawn && PlayerProperties.death == false)
        {
            Rigidbody arrowinstance;
            arrowinstance = Instantiate(arrowPrefab, spawnend.position, spawnend.rotation) as Rigidbody;
            arrowinstance.velocity = new Vector3(arrowSpeed, 0, 0);
            timetospawn += spawnrate;
        }
    }
}
