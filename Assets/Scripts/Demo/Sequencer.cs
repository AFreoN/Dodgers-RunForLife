using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour {

    public GameObject[] buttonAllower;
    public GameObject finishDemo;
    public GameObject text;
    public Transform player;

	void Start ()
    {
        finishDemo.SetActive(false);
        text.SetActive(false);
		for(int i=0;i<buttonAllower.Length;i++)
        {
            buttonAllower[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player.position.z > 80)
        {
            text.SetActive(true);
        }
		if(player.position.z >= 100)
        {
            finishDemo.SetActive(true);
        }
	}
}
