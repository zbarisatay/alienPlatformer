using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;  // Canvas üzerindeki Game Over Panelini buraya sürükle
    private bool isGameOver = false;
    public GameObject mainMenuScreen;
    public bool isGameStarted = false;
    
    void Start()
    {
        mainMenuScreen.SetActive(true);
        gameOverScreen.SetActive(false); // Başlangıçta kapalı kalsın

    }

    public void StartGame()
    {
        if (isGameStarted) return; // Tekrar tekrar çalışmasın
        isGameStarted = true;
        mainMenuScreen.SetActive(false); // Ana menüyü kapat
        Time.timeScale = 1f; // Oyunu başlat
    }
    // Karakterin canı 0 olunca burayı çağır
    public void GameOver()
    {
        if (isGameOver) return; // Tekrar tekrar çalışmasın
        isGameOver = true;

        gameOverScreen.SetActive(true); // Panel aç
        Time.timeScale = 0f; // Oyunu durdur
    }

    // Butona basınca oyunu yeniden başlat
    public void Replay()
    {
        Time.timeScale = 1f; // Zamanı normale al
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükle
        StartGame(); // Oyunu başlat
    }
}
