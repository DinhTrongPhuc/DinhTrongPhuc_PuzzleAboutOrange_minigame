using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelData[] levels;
    public int currentLevel;
    public BoardManager board;

    void Start()
    {
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int index)
    {
        board.SetupBoard(levels[index]);
    }
}
