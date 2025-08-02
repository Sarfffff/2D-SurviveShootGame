using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyenemyHealth : MonoBehaviour
{
    private int EnemyScores = 10;//��ɱ���˵õ��ķ���
    public AudioClip AudioClip;
    private ParticleSystem enemyParticle;
    private AudioSource audi;
    public int StartHealth = 100;
    private Animator anim;
    private CapsuleCollider enemyCapsuleCollider;
    public  bool isDead = false;//�Ƿ�����
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
            transform.Translate(-transform.up * Time.deltaTime*5f);//����������ʬ��������ʧ
        }
    }
    public void TakeDamage(int amount,Vector3 hitPoint)
    {
        //�жϵ����Ƿ������������������return
        if(isDead==true) 
            return;
        //�е���Ч
        audi.Play();

        StartHealth -= amount;
        enemyParticle.transform.position = hitPoint;  //������к�ֻ�ڱ�ը����һ�����Ч���ı�ը
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
        GetComponent<NavMeshAgent>().enabled = false;  //����NavMeshAgent
        GetComponent<Rigidbody>().isKinematic = true;
        audi.clip = AudioClip;//����ʱ�л�������Ч
        audi.Play();


        //����ҼƷ���������ľ�̬����+����
        MyPlayerScore.Scores += EnemyScores;
    }
    public void StartSinking()
    {
        isSiking = true;
        Destroy(gameObject,2f);
    }
}
