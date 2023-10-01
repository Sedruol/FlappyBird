using System.Collections;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;
    private GameObject[] obstacles;
    private int obstacleCount;
    private float ySpawnPosition;
    private Vector2 spawnPosition;
    void Start()
    {
        obstacles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, transform);
            obstacles[i].SetActive(false);
        }
        StartCoroutine(SpawnObstacles());
    }
    private IEnumerator SpawnObstacles()
    {
        SpawnObstacle();
        yield return new WaitForSeconds(spawnTime);
        if (!GameManager.Instance.isGameOver) StartCoroutine(SpawnObstacles());
    }
    private void SpawnObstacle()
    {
        ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;
        if (!obstacles[obstacleCount].activeSelf)
            obstacles[obstacleCount].SetActive(true);
        obstacleCount++;
        if (obstacleCount == poolSize)
            obstacleCount = 0;
    }
}