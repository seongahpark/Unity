using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    public enum Estate { Normal, Attack, Defence };
    // �Լ� ������(Function Pointer)
    // �븮�� (Delegate)
    public delegate void MyDelegate();
    private MyDelegate myDelegate = null;

    // Start is called before the first frame update
    void Start()
    {
        myDelegate = Func;
        //myDelegate();
        myDelegate += Foo;
        //myDelegate();
        myDelegate += Example;
        //myDelegate();

        //if(myDelegate != null) myDelegate(); ��� �Ⱦ��� ������ ���� ����Ѵ�.
        myDelegate.Invoke(); // ����ó���ϱ� �ξ� ��������.

        Estate.Attack.ToString();

        Estate state = Estate.Attack;
        switch (state) //alt+enter�� ������ switch �ڵ��ϼ��� ���ش�
        {
            case Estate.Normal:
                break;
            case Estate.Attack:
                break;
            case Estate.Defence:
                break;
        }
    }
    public void Func() { Debug.Log("Func"); }
    public void Foo() { Debug.Log("Foo"); }
    public void Example() { Debug.Log("Example"); }
}