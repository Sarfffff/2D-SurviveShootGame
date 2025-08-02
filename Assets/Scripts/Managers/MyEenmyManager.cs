using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    public float creatEnemyTime = 3f; // �������ʱ�䣬Ĭ�� 3 ��
    public GameObject CreatEnemyPoint;
    public float FirstEnemyTime = 1f; // ��һ�����ɵ��ӳ�ʱ�䣬Ĭ�� 1 ��

    void Start()
    {
        // ��� Enemy �� CreatEnemyPoint �Ƿ�Ϊ��
        if (Enemy == null || CreatEnemyPoint == null)
        {
            Debug.LogError("Enemy �� CreatEnemyPoint δ��ֵ������ Unity �༭���н������á�");
            return;
        }

        InvokeRepeating("Spawn", FirstEnemyTime, creatEnemyTime);
    }

    private void Spawn()
    {
        Instantiate(Enemy, CreatEnemyPoint.transform.position, CreatEnemyPoint.transform.rotation);
    }
}