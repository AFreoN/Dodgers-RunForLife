using UnityEngine;

public class DemoSpawner : MonoBehaviour
{

    objectPooler objectpooler;
    public GameObject vertBlade;

    public static float spawnDistance;
    public static float vertbla;
    public static bool singleLane = false;
    private float bladepos;

    void Start()
    {
        spawnDistance = 70.6f;
        vertbla = 70.6f;
        bladepos = 60.125f;
        objectpooler = objectPooler.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GrndSpawn")
        {
            int whichGrnd = Random.Range(0, 11);

            if (whichGrnd <= 3)
            {
                objectpooler.SpawnformPool("Blade", new Vector3(Random.Range(-3.7f, 3.7f), 0, bladepos), Quaternion.identity);
                objectpooler.SpawnformPool("Ground1", new Vector3(-1.831001f, -2.862861f, spawnDistance), Quaternion.identity);
                objectpooler.SpawnformPool("ARLeft", new Vector3(-5, 0.581f, spawnDistance - Random.Range(-9, 9)), Quaternion.Euler(0, 90, 0));
                objectpooler.SpawnformPool("ARRight", new Vector3(5, 0.581f, spawnDistance + Random.Range(-9, 9)), Quaternion.Euler(0, 270, 0));
                objectpooler.SpawnformPool("Hammer", new Vector3(0, 1.47f, spawnDistance - Random.Range(-9, 9)), Quaternion.identity);
                spawnDistance += 20.2f;
                vertbla = spawnDistance;
                bladepos += 20.2f;
            }
            else if (whichGrnd > 5 && whichGrnd <= 9)
            {
                objectpooler.SpawnformPool("Ground2", new Vector3(-1.831001f, -2.862861f, spawnDistance), Quaternion.identity);
                objectpooler.SpawnformPool("ARLeft", new Vector3(-5, 0.581f, spawnDistance - Random.Range(-9, 9)), Quaternion.Euler(0, 90, 0));
                objectpooler.SpawnformPool("ARRight", new Vector3(5, 0.581f, spawnDistance + Random.Range(-9, 9)), Quaternion.Euler(0, 270, 0));
                objectpooler.SpawnformPool("Hammer", new Vector3(0, 1.47f, spawnDistance - Random.Range(-9, 9)), Quaternion.identity);
                spawnDistance += 20.2f;
                vertbla = spawnDistance;
                bladepos += 20.2f;
            }
            else if (whichGrnd == 4 || whichGrnd == 5)
            {
                objectpooler.SpawnformPool("Ground3", new Vector3(-1.831001f, -2.862861f, spawnDistance), Quaternion.identity);
                Instantiate(vertBlade, new Vector3(2.91f, 0, spawnDistance - Random.Range(-8, 8)), Quaternion.Euler(180, 90, 0));
                Instantiate(vertBlade, new Vector3(-2.91f, 0, spawnDistance - Random.Range(-8, 8)), Quaternion.Euler(180, 90, 0));
                objectpooler.SpawnformPool("BigBlade", new Vector3(0, 0.909f, spawnDistance), Quaternion.Euler(0, Random.Range(0, 360), 0));
                spawnDistance += 20.2f;
                vertbla = spawnDistance;
                bladepos += 20.2f;
            }
            else if (whichGrnd == 10)
            {
                singleLane = true;
                objectpooler.SpawnformPool("OneWayGrnd", new Vector3(-1.831001f, -2.862861f, spawnDistance), Quaternion.identity);
                spawnDistance += 20.2f;
                vertbla = spawnDistance;
                bladepos += 20.2f;
            }
        }

    }
}
