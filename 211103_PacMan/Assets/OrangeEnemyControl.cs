using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OrangeEnemyControl : MonoBehaviour
{
    public enum State
    {
        red,
        pink,
        blue
    }

    public State state;
    NavMeshAgent agent;
    public GameManager gm;
    public EnemyControl ec;
    [SerializeField] private Transform redEnemy;
    [SerializeField] private Transform Player;

    private float changeTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        state = State.red;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isFever)
        {
            Vector3 pos = new Vector3(Player.position.x - transform.position.x, 1.5f, Player.position.z - transform.position.z);
            if (pos.magnitude < 10)
            { pos.x *= -5; pos.z *= -5; }
            agent.SetDestination(pos);
        }
        else
        {
            ChangeState();
            switch (state)
            {
                case State.red:
                    MoveLikeRed();
                    break;
                case State.pink:
                    MoveLikePink();
                    break;
                case State.blue:
                    MoveLikeBlue();
                    break;
            }
        }
    }
    private void ChangeState()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        {
            changeTime = 3.0f;
            int rand = Random.Range(0, 2);
            if (rand == 0) state = State.red;
            if (rand == 1) state = State.blue;
        }
    }

    private void MoveLikeRed()
    {
        agent.SetDestination(Player.position);
    }

    private void MoveLikeBlue()
    {
        if (redEnemy == null) agent.SetDestination(Player.position);
        else
        {
            Vector3 pos = 2 * Player.transform.position - redEnemy.transform.position;
            agent.SetDestination(pos);
        }
    }
    private void MoveLikePink()
    {
        agent.SetDestination(Player.transform.forward);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gm.isFever)
        {
            Destroy(gameObject);
        }
    }
}
