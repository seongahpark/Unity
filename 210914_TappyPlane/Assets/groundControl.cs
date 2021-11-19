using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 1.5f;
        if (this.transform.position.x <= -8.08f) {
            Vector3 pos = this.transform.position;
            pos.x += 16.16f;
            this.transform.position = pos;
        }
    }
}
