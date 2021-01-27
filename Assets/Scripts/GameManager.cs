using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject CompleteLevelUI;

    void Start()
    {
        GameIsOver = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinLevel ()
    {
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);
    }

}
