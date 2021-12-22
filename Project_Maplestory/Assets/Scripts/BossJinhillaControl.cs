using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJinhillaControl : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    private Animator anim;
    private SpriteRenderer render;

    public bool canAttack = false;
    public bool isAttack = false;
    public bool doSkill = false; //스킬을 현재 사용중인지 체크
    private bool isMove = false;
    
    public int page = 1; // 1~4페이즈

    public static int MaxBossHp = 2000;
    public int bossHp = MaxBossHp;
    private float bossMoveSpeed = 0.5f;
    private bool lookAtLeft = true;
    [SerializeField] private bool isTel = false;
    public enum CurrentState { stand, move, attack, tel, dead };
    //public CurrentState curState = CurrentState.stand;
    public CurrentState curState = CurrentState.move;

    [SerializeField] private int skillCnt = 0; // 스킬은 5번까지만 쓸 수 있도록 함


    private int monsterCnt = 0;

    private bool unHittable = false;

    [SerializeField] private Transform player;
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
        render = GetComponent<SpriteRenderer>();

        InvokeRepeating("MakeSmoke", 1.0f, 7.0f); //독구름 계속 생성
        StartCoroutine(BossAI());

    }

    // Update is called once per frame
    void Update()
    {
        PageChk();
        DebugChkSkill();
        if (isMove) Invoke("MovingMotion", 0.5f);
    }

    IEnumerator BossAI() // 보스 전반적인 움직임 제어
    {
        while(true)
        {
            if (!isAttack)
            {
                switch (curState)
                {
                    case CurrentState.stand:
                        StartCoroutine(BossIsNotMove());
                        yield return StartCoroutine(BossIsNotMove());
                        break;
                    case CurrentState.move:
                        StartCoroutine(BossMove());
                        yield return StartCoroutine(BossMove());
                        break;
                    case CurrentState.attack:
                        StartCoroutine(ChkBossPage());
                        yield return StartCoroutine(ChkBossPage());
                        break;
                    case CurrentState.tel:
                        StartCoroutine(JinhillaTeleport());
                        yield return StartCoroutine(JinhillaTeleport());
                        break;
                }
            }
            yield return null;
        }
    }
 
    IEnumerator ChkBossPage()
    {
        isAttack = true;
        anim.SetBool("move", false);
        yield return new WaitForSeconds(0.5f);
        if (!doSkill)
        {
            doSkill = true;
            if (page == 1) AttackInPage1();
            else if (page == 2) AttackInPage2();
            else if (page == 3) AttackInPage2();
            else if (page == 4) AttackInPage2();
        }
        yield return null;
    }

    private void ChkSkillCnt()
    {
        if (skillCnt > 10)
        {
            skillCnt = 0;
            curState = CurrentState.move;
            canAttack = false;
            isAttack = false;
        }
        skillCnt++;
    }
    private void AttackInPage1()
    {
        ChkSkillCnt();

        int rand = Random.Range(0, 4);    
        if (rand == 0) JinhillaAttack3();
        else if (rand == 1) JinhillaAttack4();
        else if (rand == 2) JinhillaAttack9();
        else if (rand == 3 && monsterCnt < 3) JinhillaSkill1();
    }
    private void AttackInPage2()
    {
        ChkSkillCnt();

        int rand = Random.Range(0, 5);
        if (rand == 0) JinhillaAttack3(); //파란 바인드
        else if (rand == 1) JinhillaAttack5(); //고근
        else if (rand == 2) JinhillaAttack1(); //초록가시 
        else if (rand == 3) JinhillaAttack7(); //보라가시
        else if (rand == 4 && monsterCnt < 3) JinhillaSkill1(); //욕망의 현신 소환
    }

    public void ChkCutPage()
    {
        // 낫 베기시 2page 40% 이하의 체력, 3page 20% 이하의 체력일 경우
        // 낫 베기 주기가 변경 됨
        // 2page 40% 체력 : MaxBossHp/4 * 2.4
        // 3page 20% 체력 : MaxBossHp/4 * 1.2
        float nextToCutPage2 = MaxBossHp / 4f * 2.4f;
        float nextToCutPage3 = MaxBossHp / 4f * 1.2f;
        if (gm.page_cutting == 0 && bossHp <= nextToCutPage2) gm.page_cutting = 1;
        if (gm.page_cutting == 1 && bossHp <= nextToCutPage3) gm.page_cutting = 2;
    }
    IEnumerator BossMove()
    {
        isMove = true;
        anim.SetBool("move", true);

        float rand = Random.Range(3.0f, 4.0f);
        yield return new WaitForSeconds(rand);
        isMove = false;
        if(!isTel && !canAttack) curState = CurrentState.tel;
    }

    private void MovingMotion()
    {
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
    IEnumerator BossIsNotMove()
    {
        JinhillaStand();
        float rand = Random.Range(2.5f, 4.5f);
        yield return new WaitForSeconds(rand);
        if (!isTel && !isAttack) curState = CurrentState.tel;
    }

    IEnumerator WaitForAfter(int i, float time1, float time2)
    {
        yield return new WaitForSeconds(time1);
        OnCollider(i);
        yield return new WaitForSeconds(time2);
        OffCollider(i);
        isAttack = false;
        doSkill = false;
    }

    IEnumerator WaitForAfter(GameObject obj, float time) // 델리게이트로 온오프 쓰도록..?
    {
        Instantiate(obj, transform.position, transform.rotation);
        yield return new WaitForSeconds(time);
        isAttack = false;
        doSkill = false;
    }
    private void JinhillaStand()
    {
        anim.SetBool("move", false);
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
        StartCoroutine(WaitForAfter(greenBone, 3.5f));
    }
    private void JinhillaAttack7() //보라가시
    {
        anim.SetTrigger("attack7");
        StartCoroutine(WaitForAfter(purpleBone, 3.5f));
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

        Instantiate(ball, pos, Quaternion.Euler(new Vector3(0, 180, 0)));
        Instantiate(ball, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
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
    private void JinhillaSkill1() // 욕망의 현신 소환
    {
        anim.SetTrigger("skill1");
        Invoke("MakeMonster", 1.0f);
        doSkill = false;
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
        monsterCnt++;
        // x 범위 : -9.48 ~ 9.51
        float randX = Random.Range(-9.48f, 9.51f);
        Vector3 pos = new Vector3(randX, -2.16f, 0);
        Instantiate(monster, pos, transform.rotation);
    }
    private void JinhillaSkill3() // 순간이동 (플레이어 왼, 오, 겹치게)
    {
        anim.SetTrigger("skill3");
    }

    private void GetTeleport()
    {
        Debug.Log("tel 함수 호출");
        int rand = Random.Range(0, 2);
        if (rand == 0 && curState != CurrentState.tel && !isTel) StartCoroutine(JinhillaTeleport());
    }
    IEnumerator JinhillaTeleport()
    {
        isTel = true;
        curState = CurrentState.tel;

        ResetAllTrigger(anim);

        Debug.Log("tel 함수 호출");
        anim.SetTrigger("skill3");
        unHittable = true; // 텔포동안은 무적
        yield return new WaitForSeconds(1.0f);

        render.enabled = false;
        float randTelTime = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(randTelTime);

        render.enabled = true;
        anim.SetTrigger("skill3_after");
        unHittable = false;

        //등장위치 나타내는 곳
        //플레이어 끝 : 10.9 ~ -12.58
        Vector3 playerPos = player.position;
        Vector3 bossPos = transform.position;
        if(playerPos.x > -8.5f && playerPos.x < 6.7)
        {
            int randTel = Random.Range(0, 3);
            switch (randTel)
            {
                case 0: //왼쪽, 오른쪽 바라봐야 함
                    bossPos.x = playerPos.x - 2.24f;
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    lookAtLeft = false;
                    break;
                case 1: //오른쪽
                    bossPos.x = playerPos.x + 3.24f;
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    lookAtLeft = true;
                    break;
                case 2: //겹치게
                    bossPos.x = playerPos.x;
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    lookAtLeft = true;
                    break;
            }
        }else if(playerPos.x <= -8.5f)
        {
            int randTel = Random.Range(0, 2);
            switch (randTel)
            {
                case 0: //오른쪽
                    bossPos.x = playerPos.x + 3.24f;
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    lookAtLeft = true;
                    break;
                case 1: //겹치게
                    bossPos.x = playerPos.x;
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    lookAtLeft = true;
                    break;
            }
        }
        else
        {
            bossPos.x = playerPos.x;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            lookAtLeft = true;
        }
        transform.position = bossPos;

        yield return new WaitForSeconds(1.0f);
        isTel = false;

        int rand = Random.Range(0, 3);
        if(rand == 0 ) curState = CurrentState.stand;
        else curState = CurrentState.move;
    }

    private static void ResetAllTrigger(Animator anim)
    {
        foreach(var trigger in anim.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
                anim.ResetTrigger(trigger.name);
        }
        anim.SetBool("move", false);
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

    private void PageChk()
    {
        if (bossHp < 0)
        {
            ResetAllTrigger(anim);
            JinhillaDie();
        }
        if (bossHp < 500) page = 4;
        else if (bossHp < 1000) page = 3;
        else if (bossHp < 1500) page = 2;
        else page = 1;
    }
    private void DebugChkSkill()
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
        if (Input.GetKeyDown(KeyCode.F9))
        {
            StartCoroutine(JinhillaTeleport());
        }

        if (Input.GetKey(KeyCode.X))
        {
            bossHp -= 1;
        }
    }
}
