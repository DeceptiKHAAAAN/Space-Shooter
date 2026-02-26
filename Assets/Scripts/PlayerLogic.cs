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
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * finalMoveSpeed * Time.deltaTime);

        float shootInput = Input.GetAxis("Fire1");
        if (shootInput != 0 && timeSinceLastShot > timeBetweenShots)
            SpawnLaser();
        timeSinceLastShot += Time.deltaTime;
    }
    public void SpawnLaser()
    {
        timeSinceLastShot = 0;
        Vector3 position = transform.position;
        Instantiate(playerLaser, position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            finalMoveSpeed = 1;
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            if (gameManager.GetComponent<GameManagerScript>().GameOverValue == false)
                playerHealth.DecreaseHealth();
            if (playerHealth.Health <= 0)
            {
                Destroy(gameObject);
                GameManagerScript.GameOver();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            finalMoveSpeed = moveSpeed;

    }
}
