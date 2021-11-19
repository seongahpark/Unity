using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 2;
        if (this.transform.position.x <= -50)
        {
            Destroy(this.gameObject); //화면 밖으로 나가면 삭제
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            playerControl pc = other.GetComponent<playerControl>();
            pc.playerHit();
            //코루틴함수는 일반함수처럼 함수명만 불러서 실행X
            //StartCoroutine 이라는 전용 함수를 통해 실행시킴.
            //코루틴 함수는 반환자가 IEnumerator
            //Destroy(this.gameObject);
        }
    }
}
