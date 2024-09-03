using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "arrow(Clone)")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "PlaneLeft")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "PlaneRight")
        {
            Destroy(gameObject);
        }

    }
}
