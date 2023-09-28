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
    private float timeElapsed;
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
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnTime && !GameManager.Instance.isGameOver) SpawnObstacle();
    }
    private  void SpawnObstacle()
    {
        timeElapsed = 0f;
        ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;
        if (!obstacles[obstacleCount].activeSelf)
            obstacles[obstacleCount].SetActive(true);
        obstacleCount++;
        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
