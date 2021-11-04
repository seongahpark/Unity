using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScr : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public GameManager gm;
    public EnemyControl ec;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isFever)
        {
            Vector3 pos = new Vector3(target.position.x - transform.position.x, 1.5f, target.position.z - transform.position.z);
            if (pos.magnitude < 10)
            { pos.x *= -5; pos.z *= -5; }
            agent.SetDestination(pos);
        }
        else
            agent.SetDestination(target.position);
        //agent.Warp(new Vector3(0, 0, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gm.isFever)
        {
            Destroy(gameObject);
        }
    }
}
