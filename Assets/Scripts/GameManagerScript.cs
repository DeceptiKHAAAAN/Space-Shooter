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
    private void Update()
    {
        scoreText.text = "Score: " + score;
        gameOverPanel.SetActive(gameOver);
        playerShip.GetComponent<PlayerLogic>().enabled = !gameOver;
    }
    public static void IncreaseScore()
    {
        score++;
    }
    public static void GameOver()
    {
        gameOver = true;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}