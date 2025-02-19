using System.Diagnostics;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{

    public GameObject snakeSegmentPrefab;
    public float moveInterval = 1f;

    private Vector3 direction = Vector3.right;
    private Transform snakeHead;
    private float timer = 0f;

    void Start()
    {
        if (snakeSegmentPrefab != null)
        {
            snakeHead = Instantiate(snakeSegmentPrefab, Vector3.zero, Quaternion.identity).transform;
        }
        else
        {
            //Debug.LogError("snakeSegmentPrefab is not assigned!");
        }
    }

    void Update()
    {
        if (snakeHead == null)
        {

            //Debug.LogError("snakeHead is not initialized!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector3.down)
            direction = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.up)
            direction = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right)
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector3.left)
            direction = Vector3.right;

        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            MoveSnake();
            timer = 0f;
        }
    }

    void MoveSnake()
    {
        if (snakeHead == null)
        {
            //Debug.LogError("snakeHead is not initialized!");
            return;
        }

        Vector3 newPosition = (Vector3)snakeHead.position + direction;
        snakeHead.position = newPosition;
    }
}
