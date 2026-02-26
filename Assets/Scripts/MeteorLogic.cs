using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorLogic : MonoBehaviour
{
    [SerializeField] float meteorSpeed;
    private float degreesPerSecond;
    private float rotateDirection;

    private void Start()
    {
        GameObject meteor = GameObject.FindGameObjectWithTag("Meteor");
        Physics2D.IgnoreCollision(meteor.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
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
        if (collision.gameObject.tag == "Wall")
        {
            GameManagerScript.GameOver();
        }
    }
}
