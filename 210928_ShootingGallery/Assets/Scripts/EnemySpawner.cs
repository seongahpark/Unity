using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject blueEnemy;
    [SerializeField] GameObject greenEnemy;
    [SerializeField] GameObject purpleEnemy;

    float enemyTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        if(enemyTimer > 1.0f)
        {
            enemyTimer -= 1.0f;

            int r = Random.Range(0, 11);
            //0 블루, 1 그린, 2 퍼플
            float randX = makeRandX(r);
            if(r <= 3)
            {
                GameObject obj = Instantiate(blueEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;
            }
            else if(r <= 5)
            {
                GameObject obj = Instantiate(greenEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;
            }
            else if (r <= 6)
            {
                GameObject obj = Instantiate(purpleEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;
            }
            else if (r <= 8)
            {
                GameObject obj = Instantiate(blueEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;

                GameObject obj1 = Instantiate(greenEnemy);
                Vector3 pos1 = obj1.transform.position;
                pos1.x = randX + 1.0f;
                obj1.transform.position = pos1;
            }
            else if (r <= 9)
            {
                GameObject obj = Instantiate(blueEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;

                GameObject obj1 = Instantiate(purpleEnemy);
                Vector3 pos1 = obj1.transform.position;
                pos1.x = randX + 1.0f;
                obj1.transform.position = pos1;
            }
            else if (r <= 10)
            {
                GameObject obj = Instantiate(purpleEnemy);
                Vector3 pos = obj.transform.position;
                pos.x = randX;
                obj.transform.position = pos;

                GameObject obj1 = Instantiate(blueEnemy);
                Vector3 pos1 = obj1.transform.position;
                pos1.x = randX + 1.0f;
                obj1.transform.position = pos1;

                GameObject obj2 = Instantiate(blueEnemy);
                Vector3 pos2 = obj2.transform.position;
                pos2.x = randX - 1.0f;
                obj2.transform.position = pos2;
            }
        }
    }

    private float makeRandX(int r)
    {
        if(r <= 6)
        {
            float randX = Random.Range(-2.0f, 2.0f);
            return randX;
        }
        else
        {
            float randX = Random.Range(-1.2f, 1.2f);
            return randX;
        }
    }
}
