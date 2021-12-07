using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsContrl : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AddForceToFragment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    private void AddForceToFragment()
    {
        int rand = Random.Range(0, 2);
        if(rand == 0) rb.AddForce(new Vector3(1, 0, 0) * 50);
        if(rand == 1) rb.AddForce(new Vector3(-1, 0, 0) * 50);
    }
}
