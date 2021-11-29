using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectPlayer : MonoBehaviour
{
    private BossJinhillaControl bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossJinhillaControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bc.canAttack = true;
            Debug.Log("canAttack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bc.canAttack = false;
            Debug.Log("can't Attack");
        }
    }
}