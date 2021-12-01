using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPersonalControl : MonoBehaviour
{
    private Animator anim;
    private bool isHit = false;
    private GameObject stringObj = null;
    private bool stringEnd = false;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        stringObj = transform.GetChild(0).gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("IsEnd", 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (stringEnd)
        {
            transform.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (!isHit)
        {
            anim.SetTrigger("end");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            anim.SetTrigger("attack");
            isHit = true;
        }
    }

    public void IsEnd()
    {
        stringEnd = true;
    }
}
