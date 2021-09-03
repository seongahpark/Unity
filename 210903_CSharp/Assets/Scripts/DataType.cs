using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataType : MonoBehaviour
{
    // 자료형 (DataType)
    // c#은 기본 자료형들이 클래스 형태로 만들어져 있다.
    public int i = 0;
    public float f = 0f;
    public double d = 0.0;
    public bool b = true;

    public int[] iArr = new int[3]; //기본 자료형 외에는 다 동적할당 해줘야한다.

    // Start is called before the first frame update
    void Start()
    {
        //모든 자료형과 class 들은 Object를 상속한다.
        //Object o;
        Debug.Log("int size : " + sizeof(int) + "byte");
        d = (double)i;
        Debug.Log(b.ToString());

        int[] staticArr = { 1, 2, 3 };
        int[] dynamicArr = new int[3] { 1, 2, 3 };
        //Debug.Log("staticArr Size : " + sizeof(staticArr) + "byte"); 이렇게 못함, Length를 이용해야 함
        //Debug.Log("dynamicArr Size: " + sizeof(dynamicArr) + "byte");

        Debug.Log("staticArr Length : " + staticArr.Length);
        //System.Array arr;

        //2차원 배열 선언 방법
        //1. 이 방법을 더 많이 씀
        int[,] arr2d = new int[2, 3] 
        {
            { 11, 12, 13},
            { 21, 22, 23}
        };

        //2.
        int[][] arr2d2 = new int[2][];
        arr2d2[0] = new int[3];
        arr2d2[1] = new int[10];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
