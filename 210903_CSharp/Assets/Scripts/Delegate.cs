using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    public enum Estate { Normal, Attack, Defence };
    // 함수 포인터(Function Pointer)
    // 대리자 (Delegate)
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

        //if(myDelegate != null) myDelegate(); 라고 안쓰고 다음과 같이 사용한다.
        myDelegate.Invoke(); // 예외처리하기 훨씬 편리해졌다.

        Estate.Attack.ToString();

        Estate state = Estate.Attack;
        switch (state) //alt+enter를 누르면 switch 자동완성을 해준다
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