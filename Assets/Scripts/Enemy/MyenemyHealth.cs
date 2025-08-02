using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyenemyHealth : MonoBehaviour
{
    private int EnemyScores = 10;//击杀敌人得到的分数
    public AudioClip AudioClip;
    private ParticleSystem enemyParticle;
    private AudioSource audi;
    public int StartHealth = 100;
    private Animator anim;
    private CapsuleCollider enemyCapsuleCollider;
    public  bool isDead = false;//是否死亡
    private bool isSiking = false;
    private void Awake()
    {
        audi = GetComponent<AudioSource>();
        enemyParticle = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        enemyCapsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }
    void Update()
    {
        if (isSiking)
        {
            transform.Translate(-transform.up * Time.deltaTime*5f);//死亡动画，尸体向上消失
        }
    }
    public void TakeDamage(int amount,Vector3 hitPoint)
    {
        //判断敌人是否死亡，如果死亡，则return
        if(isDead==true) 
            return;
        //中弹音效
        audi.Play();

        StartHealth -= amount;
        enemyParticle.transform.position = hitPoint;  //射击命中后只在爆炸的哪一点进行效果的爆炸
        enemyParticle.Play();
        if(StartHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Death");
        enemyCapsuleCollider.enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;  //禁用NavMeshAgent
        GetComponent<Rigidbody>().isKinematic = true;
        audi.clip = AudioClip;//死亡时切换死亡音效
        audi.Play();


        //让玩家计分类型下面的静态变量+分数
        MyPlayerScore.Scores += EnemyScores;
    }
    public void StartSinking()
    {
        isSiking = true;
        Destroy(gameObject,2f);
    }
}
