using UnityEngine;

public class PowerDemo : MonoBehaviour
{
    public GameObject player;


    public void PowerON()
    {
        AudioManager.instance.Play("SPbtn");
        player.GetComponent<MutantSP>().powerAction();
    }
}
