using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public int scoreToWin = 8;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = "Books Collected: " + score + "/8";

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (score == scoreToWin)
        {
            SceneManager.LoadScene("Start Scene");
        // Unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Reload the current scene
        SceneManager.LoadScene(0);
        }

    }
}
