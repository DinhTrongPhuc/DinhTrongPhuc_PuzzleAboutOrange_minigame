using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData")]
public class LevelData : ScriptableObject
{
    public Vector2Int[] orangePartPositions; // vị trí các mảnh cam
    public OrangePartType[] orangePartTypes; // kiểu mảnh cam tương ứng
    public Vector2Int[] obstaclePositions;   // vị trí obstacle
}
