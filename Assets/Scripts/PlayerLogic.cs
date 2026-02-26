using UnityEngine;
using TMPro;
public class PlayerLogic : MonoBehaviour
{
    [SerializeField] GameObject playerLaser;
    GameObject meteor;

    [SerializeField] float moveSpeed = 1;
    private float finalMoveSpeed;

    [SerializeField] HealthSystem playerHealth;
    
    private float timeSinceLastShot = 0;
    [SerializeField] float timeBetweenShots = 1;

    [SerializeField] GameObject gameManager;
    void Start() 
    {
        finalMoveSpeed = moveSpeed;
    }
    void Update()
    {
        // Player's Movement Input Calculation
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * finalMoveSpeed * Time.deltaTime);

        // Player's Shoot Input Calculation with limited Intervals
        float shootInput = Input.GetAxis("Fire1");
        if (shootInput != 0 && timeSinceLastShot > timeBetweenShots)
            SpawnLaser();
        timeSinceLastShot += Time.deltaTime;
    }
    // Spawns Laser at the players coordinates
    public void SpawnLaser()
    {
        timeSinceLastShot = 0;
        Vector3 position = transform.position;
        Instantiate(playerLaser, position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reduces Speed if wall has been hit to reduce stuttering into the wall
        if (collision.gameObject.tag == "Wall")
            finalMoveSpeed = 1;
        // Destroys meteor and decreases health if hit by meteor
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            if (gameManager.GetComponent<GameManagerScript>().GameOverValue == false)
                playerHealth.DecreaseHealth();
            // Checks if Player has no health remaining
            if (playerHealth.Health <= 0)
            {
                Destroy(gameObject);
                GameManagerScript.GameOver();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Speed returns after exiting collision with wall
        if (collision.gameObject.tag == "Wall")
            finalMoveSpeed = moveSpeed;
    }
}
