using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] GameObject playerLaser;
    [SerializeField] float moveSpeed = 1;
    float finalMoveSpeed;
    float timeSinceLastShot = 0;
    [SerializeField] float timeBetweenShots = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        finalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
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
        finalMoveSpeed = 1;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        finalMoveSpeed = moveSpeed;
    }
}
