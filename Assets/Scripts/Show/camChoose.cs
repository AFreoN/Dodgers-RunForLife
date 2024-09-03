using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChoose : MonoBehaviour
{
    public GameObject[] showCamera;
    private int modelNum;
    public AudioSource source;

	// Use this for initialization
	void Start ()
    {
		modelNum = PlayerPrefs.GetInt("showModel");
        for(int i=0; i<showCamera.Length; i++)
        {
            showCamera[i].SetActive(false);
        }
        showCamera[modelNum].SetActive(true);
        if(modelNum == 1)
        {
            StartCoroutine(Earthquake());
        }
    }
    IEnumerator Earthquake()
    {
        yield return new WaitForSeconds(6.8f);
        source.Play();
    }


}
