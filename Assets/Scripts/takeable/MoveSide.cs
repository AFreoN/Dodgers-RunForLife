using UnityEngine;
using System.Collections;

public class MoveSide : MonoBehaviour
{
    public float rotSpeed;
    PowerActivator PA;
    // Use this for initialization
    void Start()
    {
        PA = PowerActivator.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PA.moveSide();
            Destroy(gameObject);
        }
    }
}
