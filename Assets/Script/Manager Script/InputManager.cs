using UnityEngine;

public class InputManager : MonoBehaviour
{
    public BoardManager board;
    private Tile selectedTile;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;
    private float swipeThreshold = 30f; 

    void Update()
    {
        HandleKeyboardInput();
        HandleSwipeInput();
    }

    void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) TryMove2048(Vector2Int.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) TryMove2048(Vector2Int.down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) TryMove2048(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) TryMove2048(Vector2Int.right);
    }

    void HandleSwipeInput()
    {
        // swipe mouse
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            isSwiping = true;
        }
        else if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            endTouchPosition = Input.mousePosition;
            DetectSwipe();
            isSwiping = false;
        }

        // swipe mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
                isSwiping = false;
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude < swipeThreshold) return;

        swipeDelta.Normalize();

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            // Swipe ngang
            if (swipeDelta.x > 0)
                TryMove2048(Vector2Int.right);
            else
                TryMove2048(Vector2Int.left);
        }
        else
        {
            // Swipe doc
            if (swipeDelta.y > 0)
                TryMove2048(Vector2Int.up);
            else
                TryMove2048(Vector2Int.down);
        }
    }

    void TryMove2048(Vector2Int direction)
    {
        int dirX = direction.x;
        int dirY = -direction.y; // Y ngược trên UI

        int startX = dirX > 0 ? 3 : 0;
        int endX = dirX > 0 ? -1 : 4;
        int stepX = dirX > 0 ? -1 : 1;

        int startY = dirY > 0 ? 3 : 0;
        int endY = dirY > 0 ? -1 : 4;
        int stepY = dirY > 0 ? -1 : 1;

        for (int x = startX; x != endX; x += stepX)
        {
            for (int y = startY; y != endY; y += stepY)
            {
                GameObject obj = board.GetAt(x, y);
                if (obj != null && obj.GetComponent<Tile>() != null)
                {
                    Tile tile = obj.GetComponent<Tile>();
                    int newX = tile.X + dirX;
                    int newY = tile.Y + dirY;

                    if (board.IsEmpty(newX, newY))
                    {
                        board.MoveTile(tile, newX, newY);
                    }
                }
            }
        }
    }

    public void SelectTile(Tile tile)
    {
        selectedTile = tile;
    }
}
