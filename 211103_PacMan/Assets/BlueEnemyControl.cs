using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueEnemyControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform redEnemy;
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //점대칭 위치 구하기
    /*
     * 빨강 + 
     *  (2*빨강 - 플레이어)
     */
}
