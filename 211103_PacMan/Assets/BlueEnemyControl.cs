using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueEnemyControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform redEnemy;
    [SerializeField] private Transform Player;
    public GameManager gm;
    public EnemyControl ec;
    Renderer enemyColor;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        enemyColor = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isFever)
        {
            //ec.FeverTimeEnemy(enemyColor);
            Vector3 pos = new Vector3(Player.position.x - transform.position.x, 1.5f, Player.position.z - transform.position.z);
            if (pos.magnitude < 10)
            { pos.x *= -5; pos.z *= -5; }
            agent.SetDestination(pos);
        }
        else agent.SetDestination(ChkPos());
    }
    //Á¡´ëÄª À§Ä¡ ±¸ÇÏ±â
    /*
     * »¡°­ + 
     *  (2*»¡°­ - ÇÃ·¹ÀÌ¾î)
     */
    private Vector3 ChkPos()
    {
        Vector3 pos;
        if (redEnemy != null)
        {
            pos = 2 * Player.transform.position - redEnemy.transform.position;
        }
        else
        {
            pos = Player.transform.position;
        }
        return pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gm.isFever)
        {
            Destroy(gameObject);
        }
    }
}
