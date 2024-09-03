using UnityEngine;

public class MutantDesObs : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(MutantSP.mutantSP == true)
        {
            if(collision.gameObject == player)
            {
                Debug.Log("attacekd");
                transform.position = Vector3.zero;
            }
        }
    }
}
