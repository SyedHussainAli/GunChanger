using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemySpawn;
    private float spawnRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {

            Instantiate(enemySpawn, GenerateRandomPosition(), enemySpawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomRange = new Vector3(spawnPosX, 0.6f, spawnPosZ);

        return randomRange;
    }
}
