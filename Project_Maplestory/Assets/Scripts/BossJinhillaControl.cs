using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJinhillaControl : MonoBehaviour
{
    private Animator anim;

    public bool canAttack = false;
    
    private int page = 1; // 1~4페이즈
    private int bossHp = 1000;
    private float attackDelay = 3.0f;
    private float bossMoveSpeed = 0.5f;
    private bool lookAtLeft = true;
    [SerializeField] private bool isMove = false;
    private int isStand = 0;

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    private Vector2 colSize;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChkBossMotion();
        if (!canAttack && isMove) BossMove();
        if (canAttack && !isMove)
        {
            anim.SetBool("move", false);
            if (page == 1)
            {
                AttackInPage1();
            }
        }
    }

    private void ChkBossMotion()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jinhilla_move"))
        {
            isMove = true;
            canAttack = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jinhilla_stand"))
        {
            StartCoroutine(BossIsNotMove());
        }
        else
        {
            isMove = false;
        }
    }
    //애니메이션 상태가 move 일 때만 동작하도록?
    private void BossMove()
    {
        anim.SetBool("move", true);
        if (lookAtLeft)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.position += Vector3.left * Time.deltaTime * bossMoveSpeed;
        }
        if (!lookAtLeft)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            transform.position += Vector3.right * Time.deltaTime * bossMoveSpeed;
        }       
    }

    private void AttackInPage1()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0) anim.SetTrigger("attack3");
        else if (rand == 1) anim.SetTrigger("attack4");
        else if (rand == 2) anim.SetTrigger("attack9");
        //StartCoroutine(WaitForAfter(attackDelay));
    }

    private void AttackInPage2()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0) anim.SetTrigger("attack3"); //파란 바인드
        else if (rand == 1) anim.SetTrigger("attack5"); //고근
        else if (rand == 2) anim.SetTrigger("attack1"); //초록가시 
        else if (rand == 3) anim.SetTrigger("attack7"); //보라가시
        //StartCoroutine(WaitForAfter(attackDelay));
    }
    IEnumerator WaitForAfter(float time)
    {
        isMove = false;
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    IEnumerator BossIsNotMove()
    {
        yield return new WaitForSeconds(3.0f);
        isMove = true;
    }
}
