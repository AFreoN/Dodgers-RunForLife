using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static objectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool obj in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for(int i=0;i<obj.size;i++)
            {
                GameObject obje = Instantiate(obj.prefab);
                obje.SetActive(false);
                objectpool.Enqueue(obje);
            }
            poolDictionary.Add(obj.tag, objectpool);
        }
	}
	
    public  GameObject SpawnformPool(string tag,Vector3 position,Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objtoSpawn = poolDictionary[tag].Dequeue();
        objtoSpawn.SetActive(true);
        objtoSpawn.transform.position = position;
        objtoSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(objtoSpawn);
        return objtoSpawn;
    }
}
