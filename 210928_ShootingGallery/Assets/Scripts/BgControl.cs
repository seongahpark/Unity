using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        this.transform.position += Vector3.down * Time.deltaTime * 2;
        if(this.transform.position.y <= -7.64)
        {
            Vector3 pos = this.transform.position;
            pos.y += 15.28f;
            this.transform.position = pos;
        }
    }
}
