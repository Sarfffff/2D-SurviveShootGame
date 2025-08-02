using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    float time = 0f;
    float timeBetweenBullets = 0.15f;//射击时间的间隔
    private AudioSource gunAudio;
    private Light gunlight;
    // 定义一个计时器变量，用于控制闪烁间隔
    private float effectLightTime = 0.2f;
    private ParticleSystem gunParticl;
    private LineRenderer gunLine;


    private Ray shootRay;
    private RaycastHit shoothit;
    private int shootMask;
    private void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        gunlight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunParticl = GetComponent<ParticleSystem>();
        shootMask = LayerMask.GetMask("Enemy");
    }
    void Update()
    {
        time += Time.deltaTime;

        //获取玩家的开火箭
        //if (Input.GetButton("Fire1") && time >= timeBetweenBullets)//当冷却时间大于射击间隔是即可发射下一次
        //{
           
        //    //射击
        //    shoot();
        
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0) && time >= timeBetweenBullets)//当冷却时间大于射击间隔是即可发射下一次
        {   //射击
            shoot();
        }
        if (time >= effectLightTime * timeBetweenBullets)
        {
            gunlight.enabled = false;   //枪口灯光消失
            gunLine.enabled = false;    //枪口射线消失
        }
    }
    void shoot()
    {
        
        gunlight.enabled =true;
        time = 0f;
        gunLine.SetPosition(0, transform.position);  //两个点
       
        gunLine.enabled = true;

        gunParticl.Play();
        gunAudio.Play();


        //定义一个图层enemy，定义一个射线
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shoothit, 100, shootMask))
        {
            gunLine.SetPosition(1,shoothit.point);
            MyenemyHealth enemyHealth = shoothit.collider.GetComponent<MyenemyHealth>();  //射击射线检测到敌人，血量 - 10
            enemyHealth.TakeDamage(10,shoothit.point);
        }
        else
        {
            gunLine.SetPosition(1, transform.position+transform.forward*100);
        }

    }
}
