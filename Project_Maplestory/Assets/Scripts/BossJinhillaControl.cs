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
    [SerializeField] private bool isStand = true;

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject greenBone;
    [SerializeField] private GameObject purpleBone;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject smoke;

    List<GameObject> col = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        GetCol(); //콜라이더들 가져옴
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        JinhillaAttack1();
        InvokeRepeating("MakeSmoke", 1.0f, 7.0f); //독구름 계속 생성
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            JinhillaAttack1();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            JinhillaAttack7();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            JinhillaAttack3();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            JinhillaAttack4();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            JinhillaAttack5();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            JinhillaAttack9();
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            JinhillaStand();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            JinhillaSkill1();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            JinhillaSkill3();
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            JinhillaSkill5();
        }
        //ChkBossMotion();
        //if (!canAttack && isMove) BossMove();
        //if (canAttack && !isMove)
        //{
        //    anim.SetBool("move", false);
        //    if (page == 1)
        //    {
        //        AttackInPage1();
        //    }
        //}
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

    IEnumerator BossIsNotMove()
    {
        yield return new WaitForSeconds(3.0f);
        isMove = true;
    }

    //////////////////////////// 11.29 //////////////////////////
    IEnumerator WaitForAfter(int i, float time1, float time2)
    {
        yield return new WaitForSeconds(time1);
        OnCollider(i);
        yield return new WaitForSeconds(time2);
        OffCollider(i);
    }
    private void JinhillaStand()
    {
        for(int i=1; i<transform.childCount; i++)
        {
            col[i].SetActive(false);
        }
    }
    private void OnCollider(int i)
    {
        col[i].SetActive(true);
    }
    private void OffCollider(int i)
    {
        col[i].SetActive(false);
    }
    private void JinhillaAttack1() //초록가시
    {
        anim.SetTrigger("attack1");
        Instantiate(greenBone, transform.position, transform.rotation);
    }
    private void JinhillaAttack7() //보라가시
    {
        anim.SetTrigger("attack7");
        Instantiate(purpleBone, transform.position, transform.rotation);
    }

    private void JinhillaAttack3() //파란 바인드
    {
        anim.SetTrigger("attack3");
        StartCoroutine(WaitForAfter(1, 0.7f, 4.0f));
    }

    private void JinhillaAttack4() //반쪽 고근
    {
        anim.SetTrigger("attack4");
        StartCoroutine(WaitForAfter(2, 1.6f, 1.0f));
    }

    private void JinhillaAttack5() //고근
    {
        anim.SetTrigger("attack5");
        StartCoroutine(WaitForAfter(3, 1.6f, 1.0f));
        Invoke("MakeBall", 2.0f);   
    }

    private void MakeBall()
    {
        Vector3 pos = this.transform.position;
        pos.y -= 0.3f;
        Instantiate(ball, pos, transform.rotation);
        Instantiate(ball, pos, Quaternion.Euler(new Vector3(0, 180, 0)));
    }
    private void JinhillaAttack9() //찍기
    {
        anim.SetTrigger("attack9");
        StartCoroutine(WaitForAfter(4, 1.3f, 1.0f));
    }

    private void GetCol()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            col.Add(this.transform.GetChild(i).gameObject);
        }
    }

    /////////////// Skill ///////////////////
    private void JinhillaSkill1() // 욕망의 현신, 독구름 소환
    {
        anim.SetTrigger("skill1");
        Invoke("MakeMonster", 1.0f);
    }
    private void MakeSmoke()
    {
        // x 범위 : -9.48 ~ 9.51
        // y 범위 : -1.82 ~ 2.34
        float randX = Random.Range(-9.48f, 9.51f);
        float randY = Random.Range(-1.82f, 2.34f);
        Vector3 pos = new Vector3(randX, randY, 0);
        Instantiate(smoke, pos, transform.rotation);
    }

    private void MakeMonster()
    {
        // x 범위 : -9.48 ~ 9.51
        float randX = Random.Range(-9.48f, 9.51f);
        Vector3 pos = new Vector3(randX, -2.16f, 0);
        Instantiate(monster, pos, transform.rotation);
    }
    private void JinhillaSkill3()
    {
        anim.SetTrigger("skill3");
    }

    private void JinhillaSkill5() // 스우, 데미안 사령 소환
    {
        anim.SetTrigger("skill5");
    }

    private void JinhillaDie()
    {
        anim.SetTrigger("die");
        Destroy(gameObject, 5.0f);
    }
}
