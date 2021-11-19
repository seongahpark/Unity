using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject upperCone;
    public GameObject downCone;

    float enemyTimer = 0;
    float upperTimer = 0;
    float downTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperTimer += Time.deltaTime;
        if(upperTimer > 4.0f)
        {
            upperTimer -= 4.0f;
            int r = Random.Range(0, 3);
            float randY = Random.Range(1.1f, 2.5f);
            //0:위 / 1:아래 / 2:둘다
            if(r ==0 || r == 2)
            {
            GameObject obj1 = Instantiate(upperCone);
            Vector3 pos1 = obj1.transform.position;
                pos1.y = randY;
            obj1.transform.position = pos1;
            }

            if (r == 1 || r==2)
            {
            GameObject obj2 = Instantiate(downCone);
            Vector3 pos2 = obj2.transform.position;
            pos2.y = randY - 4;
            obj2.transform.position = pos2;
            }
        }

        //downTimer += Time.deltaTime;
        //if (downTimer > 3.0f)
        //{
        //    downTimer -= 3.0f;
        //}

        enemyTimer += Time.deltaTime;
        if(enemyTimer > 5.0f)
        {
            enemyTimer -= 5.0f;
            GameObject obj = Instantiate(enemy);
            Vector3 pos = obj.transform.position;
            pos.y = Random.Range(-1.4f, 1.4f);
            obj.transform.position = pos;
            //생성된 에너미의 위치가 랜덤하게 생성되도록 y출 좌표 설정
        }
    }
}
