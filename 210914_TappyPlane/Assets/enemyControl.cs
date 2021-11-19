using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 4;
        if (this.transform.position.x <= -50)
        {
            Destroy(this.gameObject); //화면 밖으로 나가면 삭제
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerControl pc = collision.GetComponent<playerControl>();
            if(pc.isHittable == true)
                Destroy(this.gameObject); //플레이어가 충돌 가능한 상태일때만 삭제 가능
            
            pc.playerHit();
        }
    }    
    
}
