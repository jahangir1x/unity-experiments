using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private float obstacleDestroyTime = 10f;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnPositionX = 1f;
    [SerializeField] private float spawnPositionRangeY = 1f;

    private float spawnRatePerSecond = 0.5f;
    private float elapsedTimeSinceLastSpawn = 0f;

    private void Start() {
        GameObject newObstacle = Instantiate(obstaclePrefab,
                                                transform.position,
                                                Quaternion.identity);
        newObstacle.transform.position = transform.position +
                                            new Vector3(spawnPositionX,
                                                Random.Range(-spawnPositionRangeY, spawnPositionRangeY),
                                                0);   // spawn obstacle at random position.
    }

    private void Update() {
        if (elapsedTimeSinceLastSpawn > 1f / spawnRatePerSecond) {  // if enough time has passed since last spawn, then spawn new obstacle.
            GameObject newObstacle = Instantiate(obstaclePrefab,
                                        transform.position,
                                        Quaternion.identity);
            newObstacle.transform.position = transform.position +
                                                new Vector3(spawnPositionX,
                                                    Random.Range(-spawnPositionRangeY, spawnPositionRangeY),
                                                    0);   // spawn obstacle at random position.
            elapsedTimeSinceLastSpawn = 0f; // set elapsed time to 0.
            spawnRatePerSecond = Random.Range(0.4f, 0.6f); // set spawn rate to random value.
            Destroy(newObstacle, obstacleDestroyTime);  // destroy obstacle after 10 seconds.
        }

        elapsedTimeSinceLastSpawn += Time.deltaTime;    // increment elapsed time.
    }
}
