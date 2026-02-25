using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] int laserSpeed;

    float timeSinceSpawned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > 1)
            Destroy(gameObject);
    }
}
