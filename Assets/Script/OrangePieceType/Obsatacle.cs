using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int X, Y;

    public void Init(int x, int y)
    {
        X = x;
        Y = y;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(x * 100, -y * 100);
    }
}
