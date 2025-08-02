using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    //玩家血量Text控件
    public Text PlayerHealthUi;
    //玩家受伤，遮挡层
    public Image DamageImage;
    private bool Isdamaged = false ;
    public Color FlashColor = new Color (1f,0f,0f,1f);//红色

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
            DamageImage.color = FlashColor;//受到伤害    Isdamaged画布变红
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
        //更新玩家血量UI
        PlayerHealthUi.text = PlayerHealth.ToString();
       
    }
    void Death()
    {

        //播放死亡动画
        anim.SetTrigger("Dead");
        isPlayerDead = true;
        //播放死亡音效
        Au_playerHurt.clip = Ac_playerDeath;
        Au_playerHurt.Play();


        //死亡后禁止移动和射击
        playerMovement.enabled = false;
        playershooting.enabled = false;
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);

    }
}
