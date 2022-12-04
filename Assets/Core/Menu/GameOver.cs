using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] PlayerDeath playerDeath;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI actualScore;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI coin;
    [SerializeField] PlayerScore score;
    [SerializeField] GameObject player;
    public GameObject deadMenu;

    private void Update()
    {
        if (playerDeath.isPlayerDead())
        {
            if (score.GetScore() > PlayerPrefs.GetInt("HighScore"))
                actualScore.text = "New High Score " + score.GetScore().ToString();
            else
                actualScore.text = "Your score " + score.GetScore().ToString();

            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            coin.text = PlayerPrefs.GetInt("Coins", 0).ToString();
            DeadScreen();
        }
        else
            Game();
    }

    void Game()
    {
        deadMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    private void DeadScreen()
    {
        deadMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Replay()
    {
        SaveHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackToMenu()
    {
        SaveHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private void SaveHighScore()
    {
        if (score.GetScore() > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score.GetScore());
    }
}
