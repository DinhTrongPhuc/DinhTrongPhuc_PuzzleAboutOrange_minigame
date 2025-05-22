using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public BoardManager board;

    public GameObject orangeFullPrefab;

    public float timeLimit = 45f;
    private float timer;
    public TextMeshProUGUI timerText;
    public GameObject winPanel, losePanel;
    internal static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

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

    }

    public void OnCompleteOrange(List<OrangePartCollider> parts)
    {
        // Tạo quả cam hoàn chỉnh ở vị trí trung tâm
        Vector3 center = Vector3.zero;
        foreach (var p in parts)
            center += p.transform.position;

        center /= parts.Count;

        Instantiate(orangeFullPrefab, center, Quaternion.identity);

        // Xóa các mảnh cam
        foreach (var p in parts)
            Destroy(p.gameObject);

        GameOver(true);
    }



    public void GameOver(bool win)
    {
        Time.timeScale = 0;
        if (win) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }
}

