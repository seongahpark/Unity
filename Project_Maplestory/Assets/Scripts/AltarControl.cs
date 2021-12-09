using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarControl : MonoBehaviour
{
    private Animator anim;
    private bool playerIn = false;
    [SerializeField] private int cnt = 16;
    [SerializeField] private bool noDestory = true; // 제단이 생성되자마자 진힐라가 밟는 것을 금지
    [SerializeField] CandleSetControl csc;
    [SerializeField] DeathCountContrl dc;
    // Start is called before the first frame update
    private void Awake()
    {
        csc = GameObject.FindWithTag("Candle").GetComponent<CandleSetControl>();
        dc = GameObject.FindWithTag("DeathCount").GetComponent<DeathCountContrl>();
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        cnt = 16;
        noDestory = true;
        Invoke("DoNotDestory", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ChkAltarState();
        if (playerIn && Input.GetKeyDown(KeyCode.Space)) cnt--;
    }

    private void DoNotDestory()
    {
        noDestory = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }

        if(collision.gameObject.tag == "Boss" && !noDestory)
        {
            Debug.LogError("Destoryed");
            StartCoroutine(DestroyAltar());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" && !noDestory)
        {
            Debug.LogError("Destoryed");
            StartCoroutine(DestroyAltar());
        }

        if (collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }

        if (collision.gameObject.tag == "Boss" && !noDestory)
        {
            Debug.LogError("Destoryed");
            StartCoroutine(DestroyAltar());
        }
    }
    private void ChkAltarState()
    {
        if(cnt < 0)
        {
            anim.SetTrigger("go_success");
            csc.ResetCandle();
            dc.redCnt = 0;
            dc.DCRedToWhite();
            Destroy(gameObject, 0.5f);
        }
        else if(cnt < 4)
        {
            anim.SetTrigger("go_stand3");
        }else if(cnt < 8)
        {
            anim.SetTrigger("go_stand2");
        }else if(cnt < 12)
        {
            anim.SetTrigger("go_stand1");
        }
    }

    IEnumerator DestroyAltar()
    {
        yield return new WaitForSeconds(0.5f);
        if (cnt > 12)
        {
            anim.SetTrigger("go_fail0");
        }
        else if (cnt > 8)
        {
            anim.SetTrigger("go_fail1");
        }
        else if (cnt > 4)
        {
            anim.SetTrigger("go_fail2");
        }
        else if (cnt > 0)
        {
            anim.SetTrigger("go_fail3");
        }
        yield return new WaitForSeconds(1.5f);
        csc.altarOn = false;
        Destroy(gameObject);
    }
}
