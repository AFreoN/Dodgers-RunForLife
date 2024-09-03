using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject destroyPS;
    public float rotSpeed;
    private Transform player;
    public float lerpSpeed;
    private GameObject pscontroller;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        if(PowerActivator.magnetic == true)
        {
            if (player.position.z >= transform.position.z - 10 && player.position.z <= transform.position.z+10)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x,0.8f,player.position.z), lerpSpeed);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (KnightSP.doubleCoin == false)
            {
                CoinSpawn.coins += 1;
                AudioManager.instance.Play("Coin");
            }
            else if(KnightSP.doubleCoin == true)
            {
                CoinSpawn.coins += 2;
                AudioManager.instance.Play("Coin");
                Vector3 pos = new Vector3(transform.position.x, transform.position.y , transform.position.z);
                pscontroller = Instantiate(destroyPS, pos, Quaternion.identity) as GameObject;
                Destroy(pscontroller, 1);
            }
        }
    }
}
