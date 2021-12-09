using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCountPerControl : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhiteToRed()
    {
        anim.ResetTrigger("redToWhite");
        anim.SetTrigger("whiteToRed");
    }

    public void RedToWhite()
    {
        anim.ResetTrigger("whiteToRed");
        anim.SetTrigger("redToWhite");
    }

    public void WhiteBreak()
    {
        anim.SetTrigger("whiteBreak");
    }

    public void RedBreak()
    {
        anim.SetTrigger("redBreak");
    }
}
