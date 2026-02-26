using UnityEngine;
public class LaserLogic : MonoBehaviour
{
    [SerializeField] int laserSpeed;
    float timeSinceSpawned = 0;
    void Start()
    {
        // To avoid colliding with player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void Update()
    {
        // Laser's movement
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
        // Destroys laser after 1 second passed
        timeSinceSpawned += Time.deltaTime;
        if (timeSinceSpawned > 1)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Increases score if collides with a meteor
        if (collision.gameObject.tag == "Meteor")
        {
            GameManagerScript.IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
