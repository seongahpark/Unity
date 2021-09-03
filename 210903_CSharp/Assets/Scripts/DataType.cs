using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataType : MonoBehaviour
{
    // �ڷ��� (DataType)
    // c#�� �⺻ �ڷ������� Ŭ���� ���·� ������� �ִ�.
    public int i = 0;
    public float f = 0f;
    public double d = 0.0;
    public bool b = true;

    public int[] iArr = new int[3]; //�⺻ �ڷ��� �ܿ��� �� �����Ҵ� ������Ѵ�.

    // Start is called before the first frame update
    void Start()
    {
        //��� �ڷ����� class ���� Object�� ����Ѵ�.
        //Object o;
        Debug.Log("int size : " + sizeof(int) + "byte");
        d = (double)i;
        Debug.Log(b.ToString());

        int[] staticArr = { 1, 2, 3 };
        int[] dynamicArr = new int[3] { 1, 2, 3 };
        //Debug.Log("staticArr Size : " + sizeof(staticArr) + "byte"); �̷��� ����, Length�� �̿��ؾ� ��
        //Debug.Log("dynamicArr Size: " + sizeof(dynamicArr) + "byte");

        Debug.Log("staticArr Length : " + staticArr.Length);
        //System.Array arr;

        //2���� �迭 ���� ���
        //1. �� ����� �� ���� ��
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
