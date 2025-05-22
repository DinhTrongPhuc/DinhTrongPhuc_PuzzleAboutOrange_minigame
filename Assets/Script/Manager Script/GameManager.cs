using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BoardManager board;

    public float timeLimit = 45f;
    private float timer;
    public TextMeshProUGUI timerText;
    public GameObject winPanel, losePanel;

    void Start()
    {
        timer = timeLimit;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = $"Time: {Mathf.Ceil(timer)}s";

        if (timer <= 0)
        {
            GameOver(false);
        }

        if (CheckCompleteOrange())
        {
            GameOver(true);
        }

    }

    bool CheckCompleteOrange()
    {
        return board.CheckCompleteOrange();
    }

    public void GameOver(bool win)
    {
        Time.timeScale = 0;
        if (win) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }
}

