using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject objectPrefab;
        public int size;
    }

    Queue<GameObject> objectPool;

    [SerializeField]
    private Pool pool;

    public static ObjectPoolManager Instance;

    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        objectPool = new Queue<GameObject>();

        for(int i = 0; i < pool.size; i++)
        {
            GameObject obj =  Instantiate(pool.objectPrefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

    }

    public void SpawnObjectFromPool(Vector3 position, Quaternion rotation)
    {
        if(objectPool.Count <= 1) { return; }
        
        Debug.Log("Heooo");
        GameObject spawnedObj = objectPool.Dequeue();
        spawnedObj.SetActive(true);
        spawnedObj.transform.position = position;
        spawnedObj.transform.rotation = rotation;
    }

    public void DespawnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
