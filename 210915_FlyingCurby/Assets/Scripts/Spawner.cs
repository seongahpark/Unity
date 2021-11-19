using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goldStar;
    public GameObject enemy;
    public GameObject feverStar;
    float enemyTimer = 0;
    float itemTimer = 0;
    float feverTimer = 0;
    int itemCount = 0;

    // Update is called once per frame
    void Update()
    {
        //적
        enemyTimer += Time.deltaTime;
        if(enemyTimer > 5.0f)
        {
            enemyTimer -= 5.0f;
            GameObject obj = Instantiate(enemy);
            Vector3 pos = obj.transform.position;
            pos.y = Random.Range(-2.0f, 2.0f);
            obj.transform.position = pos;
        }

        //은색 별
        itemTimer += Time.deltaTime;
        if (itemTimer > 2.0f && itemCount < 10)
        {
            itemTimer -= 2.0f;
            itemCount++;
            GameObject obj = Pooling.getIns.getItem();
            obj.transform.position = new Vector3(10, Random.Range(-1.0f, 1.0f), 0);
            obj.transform.parent = this.transform;
        }

        //금색 별
        if (itemTimer > 2.0f && itemCount >= 10)
        {
            itemTimer -= 2.0f;
            itemCount -= 10;
            itemCount++;
            GameObject obj = Instantiate(goldStar);
            obj.transform.position = new Vector3(10, Random.Range(-1.0f, 1.0f), 0);
            obj.transform.parent = this.transform;
        }

        //fever 아이템
        feverTimer += Time.deltaTime;
        if (feverTimer > 60.0f)
        {
            feverTimer -= 60.0f;
            GameObject obj = Instantiate(feverStar);
            Vector3 pos = obj.transform.position;
            pos.y = Random.Range(-2.0f, 2.0f);
            obj.transform.position = pos;
        }

    }
}
