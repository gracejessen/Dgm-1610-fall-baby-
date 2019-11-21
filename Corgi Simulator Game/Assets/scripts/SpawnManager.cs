using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 30;
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Corgi").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        
    }
}
