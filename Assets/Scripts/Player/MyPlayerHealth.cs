using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    //���Ѫ��Text�ؼ�
    public Text PlayerHealthUi;
    //������ˣ��ڵ���
    public Image DamageImage;
    private bool Isdamaged = false ;
    public Color FlashColor = new Color (1f,0f,0f,1f);//��ɫ

    public AudioClip Ac_playerDeath;
    private Animator anim;
    private AudioSource Au_playerHurt;
    public int PlayerHealth = 100;
    public bool isPlayerDead = false;


    private PlayerMovement playerMovement;
    private Playershooting playershooting;
    private void Awake()
    {
        Au_playerHurt = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playershooting = GetComponentInChildren<Playershooting>();  
    }
    void Update()
    {
        if (Isdamaged)
        {
            DamageImage.color = FlashColor;//�ܵ��˺�    Isdamaged�������
        }
        else
        {
            DamageImage.color =Color.Lerp(DamageImage.color,Color.clear,5f*Time.deltaTime);
        }
        Isdamaged = false;
    }
    public void TakeDamage(int PlayerHurt)
    {
        Isdamaged = true ;

        if(isPlayerDead) 
            return;

        Au_playerHurt.Play();
        PlayerHealth = PlayerHealth - PlayerHurt;
        if(PlayerHealth <= 0 )
        {
            Death();
        }
        //�������Ѫ��UI
        PlayerHealthUi.text = PlayerHealth.ToString();
       
    }
    void Death()
    {

        //������������
        anim.SetTrigger("Dead");
        isPlayerDead = true;
        //����������Ч
        Au_playerHurt.clip = Ac_playerDeath;
        Au_playerHurt.Play();


        //�������ֹ�ƶ������
        playerMovement.enabled = false;
        playershooting.enabled = false;
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);

    }
}
