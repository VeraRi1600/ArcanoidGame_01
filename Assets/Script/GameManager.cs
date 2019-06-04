using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public bool nextLevel;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives:" + lives;
        scoreText.text = "Score:" + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives (int changeInLives)
    {
        lives += changeInLives;
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives:" + lives;

    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score:" + score;

    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            NextLevel ();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);

    }
    void NextLevel()
    {
        nextLevel = true;
        nextLevelPanel.SetActive(true);

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void PlayAgain2()
    {
        SceneManager.LoadScene("Game1");
    }
    public void Backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
