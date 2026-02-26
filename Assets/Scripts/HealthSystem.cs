using TMPro;
using UnityEngine;
public class HealthSystem : MonoBehaviour
{
    private float health = 5;
    [SerializeField] TMP_Text healthDisplay;
    // Updates health text
    private void Start()
    {
        healthDisplay.text = "Health: " + health;
    }
    // Health getter and setter
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }
    // Decreases health and updates health display
    public void DecreaseHealth()
    {
        health--;
        healthDisplay.text = "Health: " + health;
    }
}