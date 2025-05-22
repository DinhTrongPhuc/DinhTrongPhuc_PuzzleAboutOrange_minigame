using UnityEngine;

public class Tile : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public OrangePartType partType;

    public OrangePartType Type { get; private set; }

    public void Init(int x, int y, OrangePartType type)
    {
        X = x;
        Y = y;
        partType = type;
        this.Type = type;
        SetPosition(x, y);
    }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(x * 100, -y * 100);
    }
}
