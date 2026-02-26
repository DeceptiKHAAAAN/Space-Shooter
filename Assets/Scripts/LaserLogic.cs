using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] int laserSpeed;
    float timeSinceSpawned = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > 1)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameManagerScript.IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
