using UnityEngine;

public class MeteorLogic : MonoBehaviour
{
    [SerializeField] float meteorSpeed;
    private float degreesPerSecond;
    private float rotateDirection;

    private void Start()
    {
        int randomNumber = Random.Range(0, 2);
        rotateDirection = randomNumber == 0 ? 1 : -1;
        degreesPerSecond = Random.Range(10, 70);
    }
    private void Update()
    {
        transform.Translate(Vector3.down * meteorSpeed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime * rotateDirection);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
