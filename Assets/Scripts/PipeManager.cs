using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector2Int spawnYHeightRange;
    [SerializeField] private int gapHeight;

    ObjectPoolManager objectPoolManager;

    private float lastObjSpawnedTime;
    private float randomSpawnYPosition;
    private Vector3 bottomLeftCamWP;
    private Vector3 topRigthCamWP;

    private void Start() 
    {
        objectPoolManager = ObjectPoolManager.Instance;
        bottomLeftCamWP = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,0f));
        topRigthCamWP = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
    }
    
    private void Update() 
    {
        if(Time.time > lastObjSpawnedTime)
        {
            SpawnPipes();
            lastObjSpawnedTime = Time.time + spawnRate;
            spawnRate -= 0.01f;
            spawnRate = Mathf.Clamp(spawnRate, 1.2f , 2f);
        }
    }

    private void SpawnPipes()
    {
        randomSpawnYPosition = Random.Range(spawnYHeightRange.x, spawnYHeightRange.y);

        Vector3 bottomPipeSpawnPosition = new Vector3(topRigthCamWP.x + 20f, randomSpawnYPosition - gapHeight,0f);
        objectPoolManager.SpawnObjectFromPool(bottomPipeSpawnPosition,Quaternion.identity); 

        Vector3 topPipeSpawnPosition = new Vector3(topRigthCamWP.x + 20f, randomSpawnYPosition + gapHeight, 0f);
        objectPoolManager.SpawnObjectFromPool(topPipeSpawnPosition, Quaternion.Euler(0f,0f,180f));
    }
}