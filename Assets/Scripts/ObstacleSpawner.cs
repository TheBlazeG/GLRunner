using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public float minSpawnTime, maxSpawnTime;
    public List<GameObject> obstaclesPrefabs = new List<GameObject>();
    public List<float> obstacleSpawnChances = new List<float>();
    public Transform obstacleSpawn;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnObstacles());  
    }

    private void SpawnObstacle(int obstacleIndex)
    {
        if (spawnedObstacles.Count > 0)
        {
            foreach (GameObject obstacle in spawnedObstacles)
            {
                if (obstacle.GetComponent<ObstacleClass>().myObstacleIndex == obstacleIndex)
                {
                    obstacle.transform.position = obstacleSpawn.position;
                    obstacle.SetActive(true);
                    spawnedObstacles.Add(obstacle);
                    return;
                }
            }
        }
        GameObject newObstacle = Instantiate(obstaclesPrefabs[obstacleIndex], obstacleSpawn.position, obstacleSpawn.rotation);
        newObstacle.GetComponent<ObstacleClass>().OnSpawn(obstacleIndex);
    }

    private int GetRandomObstacle()
    {
        float randomNumber = Random.Range(1, 100f);
        for (int i = 0; i < obstacleSpawnChances.Count; i++)
        {
            if (randomNumber <= obstacleSpawnChances[i])
                return i;
        }
        return 0;
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(timeToSpawn);
            SpawnObstacle(GetRandomObstacle());
        }

    }
}
