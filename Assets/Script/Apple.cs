using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Collider2D appleArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnTriggerEnter2D(null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 蘋果被碰撞事件並鎖定appleArea裡
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        float range1 = Random.Range(
            appleArea.bounds.min.x,
            appleArea.bounds.max.x
            ); // 隨機取得蘋果範圍

        float range2 = Random.Range(
            appleArea.bounds.min.y,
            appleArea.bounds.max.y
            ); // 隨機取得蘋果範圍

        transform.position = new Vector3(range1, range2, 0); // 重新設定蘋果位置
    }
}
