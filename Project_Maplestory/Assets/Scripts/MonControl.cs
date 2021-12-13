using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonControl : MonoBehaviour
{
    private Animator anim;
    private int lifeCnt = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetAttacked(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetAttacked(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GetAttacked(collision);
    }

    private void GetAttacked(Collider2D collision)
    {
        if (collision.gameObject.tag == "P_attack")
        {
            lifeCnt--;
            anim.SetTrigger("die");
            anim.SetInteger("realDie", lifeCnt);
            if (lifeCnt > 0) StartCoroutine(SetRegen());
        }
    }

    IEnumerator SetRegen()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("regen", true);
    }
}
