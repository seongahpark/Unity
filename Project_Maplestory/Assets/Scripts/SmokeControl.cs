using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeControl : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        Invoke("EndTrigger", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 6.0f);
    }

    private void EndTrigger()
    {
        anim.SetTrigger("end");
    }
}
