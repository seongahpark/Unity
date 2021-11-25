using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJinhillaControl : MonoBehaviour
{
    private Animator anim;

    private int page = 1; // 1~4페이즈
    private int bossHp = 1000;
    private bool canAttack = true;
    private float attackDelay = 3.0f;
    private float bossMoveSpeed = 1.0f;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (page == 1)
            {
                AttackInPage1();
            }
        }
    }

    private void AttackInPage1()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0) anim.SetTrigger("attack3");
        else if (rand == 1) anim.SetTrigger("attack4");
        else if (rand == 2) anim.SetTrigger("attack9");
        StartCoroutine(WaitForAfter());
    }

    private void AttackInPage2()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0) anim.SetTrigger("attack3"); //파란 바인드
        else if (rand == 1) anim.SetTrigger("attack5"); //고근
        else if (rand == 2) anim.SetTrigger("attack1"); //초록가시
        else if (rand == 3) anim.SetTrigger("attack7"); //보라가시
        StartCoroutine(WaitForAfter());
    }
    IEnumerator WaitForAfter()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
