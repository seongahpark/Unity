using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerControl>();
        //알아서 게임 오브젝트 연결해주기
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * Time.timeScale;
        if (this.transform.position.x < -10)
        {
            Pooling.getIns.returnItem(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Pooling.getIns.returnItem(this.gameObject);
            pc.score += 10;
        }
    }
}
