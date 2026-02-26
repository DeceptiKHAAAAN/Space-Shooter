using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float health = 5;
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }
    public void DecreaseHealth()
    {
        health--;
    }
}
