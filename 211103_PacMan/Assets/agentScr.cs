using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScr : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        //agent.Warp(new Vector3(0, 0, 0));
    }
}
