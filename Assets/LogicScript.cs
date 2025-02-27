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
    public GameObject titleScreen;
    public AudioSource popSFX;
    public AudioSource gameOverSFX;

    void Start()
    {
        // Gets highscore which is stored in PlayerPrefs
        highPlayerScore = PlayerPrefs.GetInt("HighScore", 0);
        // Show the title screen and freeze the game behind it
        titleScreen.SetActive(true);
        Time.timeScale = 0;
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

    public void startGame() {
        // Hide the title screen and unfreeze the game
        titleScreen.SetActive(false);
        Time.timeScale = 1;
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
