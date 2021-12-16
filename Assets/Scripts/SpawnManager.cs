using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition;
    private float xRange = 15f;
    private float spawnZ = 25f;
    private float startTime = 5f;
    private float repeatRate = 5f;
    private float randomX;
 
    void Start()
    {
         InvokeRepeating("SpawnObstacle", startTime, repeatRate);
    }

    public Vector3 RandomSpawnPosition()
    {
        randomX = Random.Range(-xRange, xRange);
        return new Vector3(randomX, 0, spawnZ);
    }

    
    public void SpawnObstacle()
    {
        spawnPosition = RandomSpawnPosition();
        Instantiate(obstaclePrefab, spawnPosition,
            obstaclePrefab.transform.rotation);
    }
}
