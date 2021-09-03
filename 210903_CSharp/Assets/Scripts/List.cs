using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    // 자료 구조
    int[] iArr;
    System.Array arr;

    ArrayList arrList = new ArrayList();

    // STL (Standard Template Library)
    // Queue<int>
    // SingleList<float>
    // Start is called before the first frame update

    List<int> intList = new List<int>();
    void Start()
    {
        // Boxing / Unboxing
        arrList.Add(1);
        arrList.Add('a');
        arrList.Add(0.4);

        for(int i=0; i<arrList.Count; i++)
        {
            Debug.Log(arrList[i].ToString());
        }

        //for, while
        //std::for_each
        //배열의 요소들을 다 출력
        foreach(object o in arrList)
        {
            Debug.Log(o);
        }

        foreach(int i in intList)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
