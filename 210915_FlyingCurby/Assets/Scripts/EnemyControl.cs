using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public PlayerControl pc;
    public GameObject explosionPrefab;
    private float posTime = 2.0f;
    private int pos = 1;
    // Update is called once per frame
    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
    void Update()
    {
        if (pc.isFever) this.transform.position += Vector3.left * Time.deltaTime * 5;
        else this.transform.position += Vector3.left * Time.deltaTime * 3;
        if(this.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }

        //맵의 좌표가 아닌 본인이 최초로 생성된 위치에서부터 시작하도록 수정..
        //적 위아래로 움직이도록 보이게 함
        //if (transform.position.y < -0.2f) pos = -1;
        //if (transform.position.y > 0.2f) pos = 1;
        //transform.Translate(Vector3.down * 0.3f * Time.deltaTime * pos);

        posTime -= Time.deltaTime;
        if (posTime > 0) pos = -1;
        if (posTime < 0) pos = 1;
        if (posTime < -2) posTime += 4;
        transform.Translate(Vector3.down * 0.3f * Time.deltaTime * pos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerControl pc = collision.GetComponent<PlayerControl>();
            
            if (pc.isHittable == true)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                //GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                //Destroy(explosion, 1f);
            }
            pc.playerHit();
        }
    }
}
