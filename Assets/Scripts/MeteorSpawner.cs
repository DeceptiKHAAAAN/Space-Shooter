using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject meteor;
    [SerializeField] float timeBetweenSpawns = 0;
    private float timeSinceLastSpawned = 0;
    void Update()
    {
        // Spawns meteors
        if (timeSinceLastSpawned > timeBetweenSpawns)
            SpawnMeteor();
        timeSinceLastSpawned += Time.deltaTime;

        // Decreases the interval of which the meteors spawn at
        timeBetweenSpawns -= Time.deltaTime * 0.01f;
        if (timeBetweenSpawns < 0.5f)
            timeBetweenSpawns = 0.5f;
    }
    private void SpawnMeteor()
    {
        // Spawns meteor at the top of the screen at various X locations
        timeSinceLastSpawned = 0;
        Vector3 randomPosition = new Vector3(Random.Range(-8.5F, 8.5F), 6, 0);
        Instantiate(meteor, randomPosition, Quaternion.identity);
    }
}
