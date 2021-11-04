using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameManager gm;
    public Transform player;
    private float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (gm.isFever) RunAwayFromPlayer();
    }

    public Vector3 RunAwayFromPlayer(Transform trans)
    {
        Vector3 dir = (player.position - trans.position).normalized;
        return dir * moveSpeed;
    }

    public bool chkRunAway(Transform trans)
    {
        Vector3 dir = trans.position - player.position;
        if (dir.magnitude < 20) return true;
        return false;
    }
}
