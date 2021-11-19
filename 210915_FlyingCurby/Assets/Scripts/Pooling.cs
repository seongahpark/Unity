using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public GameObject star;
    Queue<GameObject> obj_pool = new Queue<GameObject>();
    static Pooling ins = null;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
            //DontDestroyOnLoad(ins.gameObject);
        }
        else
        {
            Destroy(ins.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<10; i++)
        {
            GameObject obj = Instantiate(star);
            obj_pool.Enqueue(obj);
            obj.SetActive(false);
            obj.transform.parent = this.transform;
        }
    }
    
    public static Pooling getIns
    {
        get { return ins; }
    }

    public GameObject getItem()
    {
        if(obj_pool.Count > 0)
        {
            GameObject target = obj_pool.Dequeue();
            target.SetActive(true);
            return target;
        }
        else
        {
            GameObject target = Instantiate(star);
            return target;
        }
    }
    
    public void returnItem(GameObject obj)
    {
        obj_pool.Enqueue(obj);
        obj.SetActive(false);
        obj.transform.parent = this.transform;
    }
}
