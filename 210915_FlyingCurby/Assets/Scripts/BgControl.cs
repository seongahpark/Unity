using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    private void FixedUpdate()
    {
        //배경그림 2개로 계속 이어지게
        this.transform.position += Vector3.left * Time.deltaTime * 2;
        if(this.transform.position.x <= -20.4)
        {
            Vector3 pos = this.transform.position;
            pos.x += 40.8f;
            this.transform.position = pos;
        }
    }


}
