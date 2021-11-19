using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    public playerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 8.0f); //3초 뒤에 삭제
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
            pc.count += 20;
            pc.countText.text = pc.count.ToString("D3");
            Destroy(this.gameObject);
        }
    }
}
