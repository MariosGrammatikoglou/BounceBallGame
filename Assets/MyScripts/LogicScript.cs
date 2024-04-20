using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highscore;
    public GameObject gameOverScreen;
    private int currentScore;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        currentScore = playerScore;
        checkHighscore();
        updateHighscore();
        gameOverScreen.SetActive(true);
    }

    public void goToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void checkHighscore()
    {
        if(currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public void updateHighscore()
    {
        highscore.text = $"Highscore : {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
