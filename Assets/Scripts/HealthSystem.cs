using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float health = 5;
    [SerializeField] TMP_Text healthDisplay;
    private void Start()
    {
        healthDisplay.text = "Health: " + health;
    }
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }
    public void DecreaseHealth()
    {
        health--;
        healthDisplay.text = "Health: " + health;
    }
}