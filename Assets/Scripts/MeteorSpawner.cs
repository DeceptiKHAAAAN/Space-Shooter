using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject meteor;
    [SerializeField] float timeBetweenSpawns = 0;
    private float timeSinceLastSpawned = 0;
    void Update()
    {
        if (timeSinceLastSpawned > timeBetweenSpawns)
            SpawnMeteor();
        timeSinceLastSpawned += Time.deltaTime;
        timeBetweenSpawns -= Time.deltaTime * 0.01f;
        if (timeBetweenSpawns < 0.5f)
            timeBetweenSpawns = 0.5f;
    }
    private void SpawnMeteor()
    {
        timeSinceLastSpawned = 0;
        Vector3 randomPosition = new Vector3(Random.Range(-8.5F, 8.5F), 6, 0);
        Instantiate(meteor, randomPosition, Quaternion.identity);
    }
}
