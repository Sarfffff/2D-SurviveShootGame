using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    public float creatEnemyTime = 3f; // 间隔生成时间，默认 3 秒
    public GameObject CreatEnemyPoint;
    public float FirstEnemyTime = 1f; // 第一次生成的延迟时间，默认 1 秒

    void Start()
    {
        // 检查 Enemy 和 CreatEnemyPoint 是否为空
        if (Enemy == null || CreatEnemyPoint == null)
        {
            Debug.LogError("Enemy 或 CreatEnemyPoint 未赋值，请在 Unity 编辑器中进行设置。");
            return;
        }

        InvokeRepeating("Spawn", FirstEnemyTime, creatEnemyTime);
    }

    private void Spawn()
    {
        Instantiate(Enemy, CreatEnemyPoint.transform.position, CreatEnemyPoint.transform.rotation);
    }
}