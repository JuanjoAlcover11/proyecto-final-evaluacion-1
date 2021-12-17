using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition;
    private float xRange = 200f;
    private float y1Range = 0f;
    private float y2Range = 200f;
    private float zRange = 200f;
    private float startTime = 5f;
    private float repeatRate = 5f;
    private float randomX;
    private float randomY;
    private float randomZ;
 
    void Start()
    {
         InvokeRepeating("SpawnObstacle", startTime, repeatRate);
    }

    public Vector3 RandomSpawnPosition()
    {
        randomX = Random.Range(-xRange, xRange);
        randomY = Random.Range(y1Range, y2Range);
        randomZ = Random.Range(-zRange, zRange);
        return new Vector3(randomX, randomY, randomZ);
    }

    
    public void SpawnObstacle()
    {
        spawnPosition = RandomSpawnPosition();
        Instantiate(obstaclePrefab, spawnPosition,
            obstaclePrefab.transform.rotation);
    }
}
