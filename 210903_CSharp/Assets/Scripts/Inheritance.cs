using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance : MonoBehaviour
{

    public class Parent
    {
        protected virtual void Start() //protected virtual인 경우는 자식에도 protected 써줘야 됨
        {

        }

        virtual public void Func() // 자식이 재정의를 하기 위해서는 virtual 적어줘야 함
        {

        }

        public void Func(int _val)
        {
            // 함수 오버로딩 Overloading
        }
    }

    public class Child : Parent
    {
        // Overriding
        public override void Func() //부모가 가진 것을 재정의
        {

        }

        protected override void Start() 
        {
            this.Start(); //child의 Start 호출, this의 색이 연하므로 생략해도 된다는 뜻
            base.Start(); //parent의 Start 호출
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
