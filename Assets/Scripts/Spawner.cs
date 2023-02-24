using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 1f;
    private float spawnTimer;
    [SerializeField] private float xMinPos = -47f;
    [SerializeField] private float xMaxPos = 47f;
    [SerializeField] private float zPos = 180f;
    [SerializeField] private float yPos = 2f;


    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0 )
        {
            spawnTimer = spawnDelay;
            float randomSpawnLocation = Random.Range(xMinPos, xMaxPos);
            Vector3 randomSpawnVector = new Vector3(randomSpawnLocation, yPos, zPos);
            SpawnGrunt(randomSpawnVector);
        }
    }

    private void SpawnGrunt(Vector3 spawnLocation)
    {
        Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
    }
}
