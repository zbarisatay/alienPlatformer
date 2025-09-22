using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreenPanel; 

    void Start()
    {
        winScreenPanel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winScreenPanel.SetActive(true);
        Time.timeScale = 0f; 
        Debug.Log("Kazandın!");
    }
}
