using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Rigidbody arrowPrefab;
    public Transform spawnend;
    private float timetospawn;
    public static float spawnrate = 1;
    public float arrowSpeed;
    public ParticleSystem ps;
    float dis;

	// Use this for initialization
	void Start ()
    {
        dis = transform.position.z;
        timetospawn = Time.time + spawnrate* PlayerProperties.arrowSpwnFactor;
        var val = ps.main;
        val.startLifetime = spawnrate * PlayerProperties.arrowSpwnFactor;
	}

    // Update is called once per frame
    void Update ()
    {
        if(PlayerProperties.death == false && ps.isStopped == true)
        {
            ps.Play();
        }
        if(PlayerProperties.death == true && ps.isPlaying == true)
        {
            ps.Stop();
        }
        if(transform.position.z > dis)
        {
            var val = ps.main;
            val.startLifetime = spawnrate * PlayerProperties.arrowSpwnFactor;
            dis = transform.position.z;
        }
        if (Time.time > timetospawn && PlayerProperties.death == false)
        {
            Rigidbody arrowinstance;
            arrowinstance = Instantiate(arrowPrefab, spawnend.position,spawnend.rotation ) as Rigidbody;
            arrowinstance.velocity = new Vector3(arrowSpeed/PlayerProperties.timer, 0, 0);
            timetospawn += spawnrate*PlayerProperties.arrowSpwnFactor;
            var val = ps.main;
            val.startLifetime = spawnrate * PlayerProperties.arrowSpwnFactor;
        }
        else if(PlayerProperties.death == true)
        {
            timetospawn = Time.time + spawnrate * PlayerProperties.arrowSpwnFactor;
        }
	}
}
