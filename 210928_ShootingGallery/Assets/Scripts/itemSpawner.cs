using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [SerializeField] GameObject item;
    private float itemTimer = 0;

    // Update is called once per frame
    void Update()
    {
        itemTimer += Time.deltaTime;
        if (itemTimer >= 20.0f)
        {
            itemTimer -= 20.0f;
            float randX = Random.Range(-2.0f, 2.0f);
            GameObject obj = Instantiate(item);
            Vector3 pos = obj.transform.position;
            pos.x = randX;
            obj.transform.position = pos;
        }
    }
}
