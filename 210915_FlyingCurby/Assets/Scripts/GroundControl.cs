using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += Vector3.left * Time.deltaTime * Time.timeScale;
        if(this.transform.position.x <= -28.09f)
        {
            Vector3 pos = this.transform.position;
            pos.x += 56.18f;
            this.transform.position = pos;
        }
    }
}
