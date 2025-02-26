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
    public AudioSource popSFX;
    public AudioSource gameOverSFX;

    void Start()
    {
        // Gets highscore which is stored in PlayerPrefs
        highPlayerScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        // Bubble pop sound effect for getting a point
        popSFX.Play();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        gameOverSFX.Play();
    }

    public void UpdateHighScore() {
        // Change high score is player score is larger
        if (playerScore > highPlayerScore) {
            highPlayerScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highPlayerScore);
        }

        // Update high score text to reflect any changes in high score
        highScoreText.text = highPlayerScore.ToString();
    }
}
