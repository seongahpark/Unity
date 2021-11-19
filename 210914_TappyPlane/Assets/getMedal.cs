using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMedal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 2.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.GetComponent<playerControl>().hitMedal();
            Destroy(this.gameObject);
        }
    }
}
