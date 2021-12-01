using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    Renderer rend;

    private bool up = true;
    private float direction = 0.3f;
    private float dirTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        int rand = Random.Range(0, 2);
        if (rand == 0) up = true;
        if (rand == 1) up = false;
    }

    // Update is called once per frame
    void Update()
    {
        float shininess = Mathf.PingPong(Time.time*0.5f, 0.5f);
        rend.material.SetFloat("_Brightness", shininess);
        ChkDir();
        Moving();
    }
    
    private void ChkDir()
    {
        dirTime -= Time.deltaTime;
        if(dirTime < 0)
        {
            up = !up;
            dirTime = 1.5f;
        } 
    }
    private void Moving()
    {
        if (up)
        {
            transform.position += Vector3.up * Time.deltaTime * direction;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * direction;
        }
    }
}
