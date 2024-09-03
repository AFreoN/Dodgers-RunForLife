using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDeload : MonoBehaviour {

    public GameObject player;

    private void OnEnable()
    {
        if(player.activeInHierarchy == true)
        {
            player.SetActive(false);
        }
    }
}
