using UnityEngine;

public class LowPlane : MonoBehaviour
{
    public static bool follow = true;
    public Rigidbody rb;
    public Transform[] player;
    private int modelnum;
    public float moveSpeed;

    private void Start()
    {
        modelnum = PlayerPrefs.GetInt("CurrentModel", 0);
    }
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, player[modelnum].position.z);
        rb.velocity = new Vector3(0, 0, moveSpeed*Time.deltaTime);
        if (transform.position.z < player[modelnum].position.z-20)
        {
            transform.position = new Vector3(-3.5763e-07f, -1.67f, player[modelnum].position.z + 20);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            follow = false;
        }
    }
}
