using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour // 公開的
{
    private Vector3 direction;
    public Collider2D snakeArea;
    public Transform bodyPrefeb; // 蛇身

    public List<Transform> bodys = new List<Transform>(); // 蛇身陣列

    public float speed; // 可從Unity介面調整遊戲速度

    void Start()
    {
        Debug.Log("開始遊戲");
        Time.timeScale = 0.3f; // 遊戲速度0.1倍
        RandonSnakePosition(); // 隨機設定蛇位置
        bodys.Add(transform); // 蛇身陣列加入蛇頭
        // direction = Vector3.right;
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
        for (int i = bodys.Count - 1; i > 0; i--)
        {
            bodys[i].position = bodys[i - 1].position; // 蛇身位置等於前一個蛇身位置
        }
        transform.Translate(direction); // 向右邊移動
    }

    void RandonSnakePosition()
    {
        float range1 = Random.Range(
            snakeArea.bounds.min.x,
            snakeArea.bounds.max.x
            ); // 隨機取得蘋果範圍

        float range2 = Random.Range(
            snakeArea.bounds.min.y,
            snakeArea.bounds.max.y
            ); // 隨機取得蘋果範圍

        transform.position = new Vector3(range1, range2, 0); // 重新設定蘋果位置
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.CompareTag("Apple"))
        {
            bodys.Add(Instantiate(
                bodyPrefeb,
                transform.position, // 身體重生在蛇頭後方
                Quaternion.identity // 身體不旋轉
                )); // 蛇身陣列加入蛇身
            AddBodySegments(10);
        }
    }

    // 外掛:增加蛇身
    void AddBodySegments(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform newBody = Instantiate(bodyPrefeb);
            newBody.position = bodys[bodys.Count - 1].position; // 新蛇身位置設為最後一個蛇身的位置
            bodys.Add(newBody); // 蛇身陣列加入新蛇身
        }
    }
}
