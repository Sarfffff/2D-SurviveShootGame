using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    public int EnemyAttackDamage = 20;  //enemy�Ĺ�����
    private MyPlayerHealth Myplayerhealth;  
    private bool playerInRange;  //�ж�����Ƿ���enemy�Ĵ�������
    private  GameObject player;
    private float Timer = 0;//���˹�����ʱ����

    private Animator anim;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Myplayerhealth = player.GetComponent<MyPlayerHealth>();
        anim = GetComponent<Animator>();
    }
  
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (playerInRange&&Timer >0.5f&&!Myplayerhealth.isPlayerDead)
        {
            //���������player�ܽ�����˺�
            Attack();
        }
        if (Myplayerhealth.isPlayerDead)//���player������isPlayerDead = true)��enemy��ֹ����
        {
            anim.SetTrigger("PlayerDead");//����enemy�ľ�ֹ����
        }
    }


    private void Attack()
    {
        Timer = 0;
        //��ȡ������ 
        Myplayerhealth.TakeDamage(EnemyAttackDamage);


    }
    private void OnTriggerEnter(Collider other)//enemy�ĵ��˴��������൱�ڹ�����Χ��
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
}
