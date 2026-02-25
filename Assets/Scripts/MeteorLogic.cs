using UnityEngine;

public class MeteorLogic : MonoBehaviour
{
    [SerializeField] float meteorSpeed;
    private void Update()
    {
        transform.Translate(Vector3.down * meteorSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
