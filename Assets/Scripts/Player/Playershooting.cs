using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    float time = 0f;
    float timeBetweenBullets = 0.15f;//���ʱ��ļ��
    private AudioSource gunAudio;
    private Light gunlight;
    // ����һ����ʱ�����������ڿ�����˸���
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

        //��ȡ��ҵĿ����
        //if (Input.GetButton("Fire1") && time >= timeBetweenBullets)//����ȴʱ������������Ǽ��ɷ�����һ��
        //{
           
        //    //���
        //    shoot();
        
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0) && time >= timeBetweenBullets)//����ȴʱ������������Ǽ��ɷ�����һ��
        {   //���
            shoot();
        }
        if (time >= effectLightTime * timeBetweenBullets)
        {
            gunlight.enabled = false;   //ǹ�ڵƹ���ʧ
            gunLine.enabled = false;    //ǹ��������ʧ
        }
    }
    void shoot()
    {
        
        gunlight.enabled =true;
        time = 0f;
        gunLine.SetPosition(0, transform.position);  //������
       
        gunLine.enabled = true;

        gunParticl.Play();
        gunAudio.Play();


        //����һ��ͼ��enemy������һ������
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shoothit, 100, shootMask))
        {
            gunLine.SetPosition(1,shoothit.point);
            MyenemyHealth enemyHealth = shoothit.collider.GetComponent<MyenemyHealth>();  //������߼�⵽���ˣ�Ѫ�� - 10
            enemyHealth.TakeDamage(10,shoothit.point);
        }
        else
        {
            gunLine.SetPosition(1, transform.position+transform.forward*100);
        }

    }
}
