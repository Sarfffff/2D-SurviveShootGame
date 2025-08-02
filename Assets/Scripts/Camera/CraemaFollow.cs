using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraemaFollow : MonoBehaviour
{
    private float Smoothing = 5f;
    private GameObject player;
    private Vector3 offset;  //三维向量
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()   //开始的时候找到相机与玩家的距离差值
    {
        offset = transform.position - player.transform.position;   //相机的位置 - 玩家当前的位置(向量间的)

    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,offset + player.transform.position,Smoothing*Time.deltaTime);    //相机的位置 = 差值 + 玩家当前的位置，相机跟随
    }
}
