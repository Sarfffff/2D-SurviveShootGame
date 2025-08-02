using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    public int EnemyAttackDamage = 20;  //enemy的攻击力
    private MyPlayerHealth Myplayerhealth;  
    private bool playerInRange;  //判断玩家是否在enemy的触发器中
    private  GameObject player;
    private float Timer = 0;//敌人攻击的时间间隔

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
            //敌人如果离player很近造成伤害
            Attack();
        }
        if (Myplayerhealth.isPlayerDead)//如果player死亡（isPlayerDead = true)，enemy静止不动
        {
            anim.SetTrigger("PlayerDead");//播放enemy的静止动画
        }
    }


    private void Attack()
    {
        Timer = 0;
        //获取玩家组件 
        Myplayerhealth.TakeDamage(EnemyAttackDamage);


    }
    private void OnTriggerEnter(Collider other)//enemy的敌人触发器（相当于攻击范围）
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
