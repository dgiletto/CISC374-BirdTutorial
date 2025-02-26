using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highPlayerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;

    void Start()
    {
        highPlayerScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    public void UpdateHighScore() {
        if (playerScore > highPlayerScore) {
            highPlayerScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highPlayerScore);
        }

        highScoreText.text = highPlayerScore.ToString();
    }
}
