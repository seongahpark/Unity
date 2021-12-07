using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPersonalControl : MonoBehaviour
{
    private Animator anim;
    private Animator anim_string;
    public bool isHit = false;
    [SerializeField] private bool canHit = false;
    private GameObject stringObj = null;
    private bool stringEnd = false;

    private CandleSetControl cc;
    [SerializeField] private GameObject[] fragment = new GameObject[3];
    
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        stringObj = transform.GetChild(0).gameObject;
        cc = GameObject.FindWithTag("Candle").GetComponent<CandleSetControl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        stringObj.SetActive(true);
        //Invoke("IsEnd", 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            StartCoroutine(GoToEnd());
        }
        if (stringEnd)
        {
            StartCoroutine(ReLoad());
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("hand_appear"))
        {
            stringObj.SetActive(true);
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("hand_appear"))
        {
            stringObj.SetActive(false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Empty"))
        {
            IsEnd();
        }
    }

    private void setCanHit()
    {
        canHit = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && canHit)
        {
            Debug.Log("collision");
            anim.SetTrigger("attack");
            isHit = true;
            canHit = false;
            cc.flameCnt++;
            Invoke("MakeFragments", 6.5f);
        }
    }

    IEnumerator GoToEnd()
    {
        yield return new WaitForSeconds(0.4f);
        setCanHit();
        yield return new WaitForSeconds(0.5f);
        if (!isHit)
        {
            anim.SetTrigger("end");
        }
    }

    public void IsEnd()
    {
        stringEnd = true;
    }

    IEnumerator ReLoad()
    {
        anim.SetTrigger("appear");
        yield return new WaitForSeconds(0.1f);
        stringEnd = false;
        isHit = false;
        canHit = false;
        transform.gameObject.SetActive(false);
        stringObj.SetActive(false);
    }

    private void MakeFragments()
    {
        Vector3 pos = this.transform.position;
        pos.x -= 2.0f;
        for(int i=0; i<3; i++)
        {
            Instantiate(fragment[i], pos, Quaternion.identity);
            pos.x += 2.0f;
        }
    }
}
