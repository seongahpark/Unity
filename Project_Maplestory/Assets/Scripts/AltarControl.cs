using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarControl : MonoBehaviour
{
    private Animator anim;
    private bool playerIn = false;
    [SerializeField] private int cnt = 16;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        cnt = 16;
    }

    // Update is called once per frame
    void Update()
    {
        ChkAltarState();
        if (playerIn && Input.GetKeyDown(KeyCode.Space)) cnt--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }

        if(collision.gameObject.tag == "Boss")
        {
            Debug.LogError("Destoryed");
            Invoke("DestroyAltar", 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }
    private void ChkAltarState()
    {
        if(cnt < 0)
        {
            anim.SetTrigger("go_success");
        }else if(cnt < 4)
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

    private void DestroyAltar()
    {
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
        Destroy(gameObject, 0.8f);
    }
}
