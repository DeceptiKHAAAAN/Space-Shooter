using UnityEngine;
public class MeteorLogic : MonoBehaviour
{
    float meteorSpeed;
    private float degreesPerSecond;
    private float rotateDirection;

    private void Start()
    {
        // Code for meteor to not collide with each other and destroy each other
        GameObject meteor = GameObject.FindGameObjectWithTag("Meteor");
        Physics2D.IgnoreCollision(meteor.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());

        // Implements a slight rotation in varying degrees and directions to each meteor
        int randomNumber = Random.Range(0, 2);
        rotateDirection = randomNumber == 0 ? 1 : -1;
        degreesPerSecond = Random.Range(10, 70);

        // Randomize meteorSpeed
        meteorSpeed = Random.Range(2, 4);
    }
    // Meteor's Movement and Rotation update
    private void Update()
    {
        transform.Translate(Vector3.down * meteorSpeed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime * rotateDirection);
    }
    // Calls GameOver() when meteor touches the bottom barrier
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameManagerScript.GameOver();
            Destroy(gameObject);
        }
    }
}
