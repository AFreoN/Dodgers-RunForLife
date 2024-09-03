using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float rotSpeed;
    public static bool magnetic = false;
    PowerActivator PA;

    void Start () {
        PA = PowerActivator.Instance;
	}
	
	void Update ()
    {
        transform.Rotate(new Vector3(0,rotSpeed * Time.deltaTime,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PA.magnet();
            Destroy(gameObject);
        }
    }
}
