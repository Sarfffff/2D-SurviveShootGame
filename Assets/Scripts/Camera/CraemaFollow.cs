using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraemaFollow : MonoBehaviour
{
    private float Smoothing = 5f;
    private GameObject player;
    private Vector3 offset;  //��ά����
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()   //��ʼ��ʱ���ҵ��������ҵľ����ֵ
    {
        offset = transform.position - player.transform.position;   //�����λ�� - ��ҵ�ǰ��λ��(�������)

    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,offset + player.transform.position,Smoothing*Time.deltaTime);    //�����λ�� = ��ֵ + ��ҵ�ǰ��λ�ã��������
    }
}
