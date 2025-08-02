using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Myenemy : MonoBehaviour
{
    private NavMeshAgent nav;
    private GameObject player;
    private MyenemyHealth myEnemyhealth;
    private MyPlayerHealth myPlayerhealth;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        myEnemyhealth = GetComponent<MyenemyHealth>();  
        myPlayerhealth = player.GetComponent<MyPlayerHealth>();
    }
     void Update()
    {
        //判断是否死亡，如果死亡，不在进行导航坐标点的设置，不在跟随player
        if(!myEnemyhealth.isDead&&!myPlayerhealth.isPlayerDead)
            nav.SetDestination(player.transform.position);
        else
            nav.enabled = false;
        
    }
    
}
