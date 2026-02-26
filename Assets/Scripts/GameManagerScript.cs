using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerShip;
    [SerializeField] TMP_Text scoreText;
    private static int score;
    private static bool gameOver;
    public void Start()
    {
        gameOver = false;
        score = 0;
    }
    // Updates the score and checks for gameOver conditions
    private void Update()
    {
        scoreText.text = "Score: " + score;
        gameOverPanel.SetActive(gameOver);
        playerShip.GetComponent<PlayerLogic>().enabled = !gameOver;
        playerShip.GetComponent<HealthSystem>().enabled = !gameOver;
    }
    // Increases Score
    public static void IncreaseScore()
    { 
        score++;
        
    }
    // Makes gameOver true;
    public static void GameOver() 
    { 
        gameOver = true; 
    }
    // Allows other scripts to get gameOver value
    public bool GameOverValue
    { 
        get { return gameOver;  }
        private set { gameOver = value; } 
    }
    // Resets the game
    public void ResetScene() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    // Quits application or stops editor application
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}