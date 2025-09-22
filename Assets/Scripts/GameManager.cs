using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen; 
    private bool isGameOver = false;
    public GameObject mainMenuScreen;
    public bool isGameStarted = false;
    
    void Start()
    {
        mainMenuScreen.SetActive(true);
        gameOverScreen.SetActive(false); 

    }

    public void StartGame()
    {
        if (isGameStarted) return; 
        isGameStarted = true;
        mainMenuScreen.SetActive(false); 
        Time.timeScale = 1f; 
    }
    
    public void GameOver()
    {
        if (isGameOver) return; 
        isGameOver = true;

        gameOverScreen.SetActive(true); 
        Time.timeScale = 0f;
    }

    
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        StartGame(); 
    }
}
