using UnityEngine;

public class SnakeGame : MonoBehaviour // 公開的
{
    private Vector3 direction;
    public Collider2D snakeArea;


    public float speed; // 可從Unity介面調整遊戲速度

    void Start()
    {
        Debug.Log("開始遊戲");
        Time.timeScale = 0.3f; // 遊戲速度0.1倍
        RandonSnakePosition(); // 隨機設定蛇位置
        direction = Vector3.right;
    }

    void Update()
    {
        // W S A D
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Debug.Log("方向上");
            direction = Vector3.up;

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //     Debug.Log("方向下");
            direction = Vector3.down;

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Debug.Log("方向左");
            direction = Vector3.left;

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Debug.Log("方向右");
            direction = Vector3.right;

        }
    }

    void FixedUpdate() // 固定更新FPS
    {
        transform.Translate(direction); // 向右邊移動
    }

    void RandonSnakePosition()
    {
        float range1 = UnityEngine.Random.Range(
            snakeArea.bounds.min.x,
            snakeArea.bounds.max.x
            ); // 隨機取得蘋果範圍

        float range2 = UnityEngine.Random.Range(
            snakeArea.bounds.min.y,
            snakeArea.bounds.max.y
            ); // 隨機取得蘋果範圍

        transform.position = new Vector3(range1, range2, 0); // 重新設定蘋果位置
    }

}
