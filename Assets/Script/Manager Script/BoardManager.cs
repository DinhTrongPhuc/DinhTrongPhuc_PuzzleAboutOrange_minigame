using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public GameObject[] orangePartPrefabs; 
    public GameObject obstaclePrefab;
    public Transform boardParent; 
    public Vector2 cellSize = new Vector2(125, 125); 
    private GameObject[,] grid = new GameObject[4, 4];

    public void SetupBoard(LevelData data)
    {
        ClearBoard();

        for (int i = 0; i < data.orangePartPositions.Length; i++)
        {
            var pos = data.orangePartPositions[i];
            var type = data.orangePartTypes[i];
            var obj = Instantiate(orangePartPrefabs[(int)type], boardParent);
            obj.GetComponent<Tile>().Init(pos.x, pos.y, type);
            PlaceAt(pos.x, pos.y, obj);
        }

        foreach (var pos in data.obstaclePositions)
        {
            var obstacle = Instantiate(obstaclePrefab, boardParent);
            obstacle.GetComponent<Obstacle>().Init(pos.x, pos.y);
            PlaceAt(pos.x, pos.y, obstacle);
        }
    }

    public void ClearBoard()
    {
        foreach (Transform child in boardParent)
            Destroy(child.gameObject);

        grid = new GameObject[4, 4];
    }

    public void PlaceAt(int x, int y, GameObject obj)
    {
        grid[x, y] = obj;
        RectTransform rect = obj.GetComponent<RectTransform>();

        float boardWidth = 4 * cellSize.x;
        float boardHeight = 4 * cellSize.y;

        float offsetX = -boardWidth / 2f + cellSize.x / 2f;
        float offsetY = boardHeight / 2f - cellSize.y / 2f;

        float anchoredX = x * cellSize.x + offsetX;
        float anchoredY = -y * cellSize.y + offsetY;

        rect.anchoredPosition = new Vector2(anchoredX, anchoredY);

    }

    public bool CheckCompleteOrange()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                GameObject tl = GetAt(x, y);
                GameObject tr = GetAt(x + 1, y);
                GameObject br = GetAt(x + 1, y + 1);
                GameObject bl = GetAt(x, y + 1);

                if (tl != null && tr != null && br != null && bl != null)
                {
                    Tile tileTL = tl.GetComponent<Tile>();
                    Tile tileTR = tr.GetComponent<Tile>();
                    Tile tileBR = br.GetComponent<Tile>();
                    Tile tileBL = bl.GetComponent<Tile>();

                    if (tileTL.Type == OrangePartType.TopLeft &&
                        tileTR.Type == OrangePartType.TopRight &&
                        tileBR.Type == OrangePartType.BottomRight &&
                        tileBL.Type == OrangePartType.BottomLeft)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    public bool IsEmpty(int x, int y)
    {
        return InBounds(x, y) && grid[x, y] == null;
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < 4 && y >= 0 && y < 4;
    }

    public GameObject GetAt(int x, int y) => InBounds(x, y) ? grid[x, y] : null;

    public void MoveTile(Tile tile, int newX, int newY)
    {
        grid[tile.X, tile.Y] = null;
        tile.SetPosition(newX, newY);
        PlaceAt(newX, newY, tile.gameObject);
    }
}
