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
            Destroy(this.gameObject); //ȭ�� ������ ������ ����
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            playerControl pc = other.GetComponent<playerControl>();
            pc.playerHit();
            //�ڷ�ƾ�Լ��� �Ϲ��Լ�ó�� �Լ��� �ҷ��� ����X
            //StartCoroutine �̶�� ���� �Լ��� ���� �����Ŵ.
            //�ڷ�ƾ �Լ��� ��ȯ�ڰ� IEnumerator
            //Destroy(this.gameObject);
        }
    }
}
