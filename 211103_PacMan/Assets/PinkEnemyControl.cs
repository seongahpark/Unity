using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PinkEnemyControl : MonoBehaviour
{
    NavMeshAgent agent;
    public GameManager gm;
    public EnemyControl ec;
    [SerializeField] private Transform Player;
    private float distance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어의 앞을 막아야되는 상황
        //Raycast를 이용해서 구현
        if (gm.isFever)
        {
            Vector3 pos = new Vector3(Player.position.x - transform.position.x, 1.5f, Player.position.z - transform.position.z);
            if (pos.magnitude < 10)
            { pos.x *= -5; pos.z *= -5; }
            agent.SetDestination(pos);
        }
        else
        {
            if (!ChkPos())
                agent.SetDestination(Player.position);
        }
    }
    private bool ChkPos()
    {
        Vector3 rayOrigin = Player.position;
        Vector3 rayDir = Player.transform.forward;
        Debug.Log(Physics.Raycast(rayOrigin, rayDir, distance));
        return Physics.Raycast(rayOrigin, rayDir, distance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && gm.isFever)
        {
            Destroy(gameObject);
        }
    }
}
