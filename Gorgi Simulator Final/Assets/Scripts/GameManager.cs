using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] ObsticalPrefabs;
    public GameObject[] PowerupPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 5;
    private float startDelay = 2;
    private float repeatRate = 2;
    private float counter = 0;
    private PlayerController playerControllerScript;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnPowerup", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Corgi").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -1, spawnPosZ);
        int obsticalIndex = Random.Range(0, ObsticalPrefabs.Length);
        Instantiate(ObsticalPrefabs[obsticalIndex], spawnPos, ObsticalPrefabs[obsticalIndex].transform.rotation);
        
    }
    void SpawnPowerup()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -1, spawnPosZ);
        int PowerupIndex = Random.Range(0, PowerupPrefabs.Length);
        Instantiate(PowerupPrefabs[PowerupIndex], spawnPos, PowerupPrefabs[PowerupIndex].transform.rotation);
        
    }
}



/*if(capsule or chicken is hit)
{
    counter += 1;
}*/