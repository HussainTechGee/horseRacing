using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class my_Pool
    {
        public string name;
        public GameObject objectPoefab;
        public int size;
    }
    public static ObjectPooler instance;
    public Dictionary<string, Queue<GameObject>> D_pooler;
    public my_Pool[] Pool;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        D_pooler = new Dictionary<string, Queue<GameObject>>();
        foreach (my_Pool pool in Pool)
        {
            Queue<GameObject> pooledObject = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject tempobj = Instantiate(pool.objectPoefab);
                tempobj.SetActive(false);
                pooledObject.Enqueue(tempobj);
            }
            D_pooler.Add(pool.name, pooledObject);
        }
    }

    public GameObject SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!D_pooler.ContainsKey(name))
        {
            Debug.Log("Not Exist" + name);
            return null;
        }
        GameObject objectToSpawn = D_pooler[name].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        D_pooler[name].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
