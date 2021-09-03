using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance : MonoBehaviour
{

    public class Parent
    {
        protected virtual void Start() //protected virtual�� ���� �ڽĿ��� protected ����� ��
        {

        }

        virtual public void Func() // �ڽ��� �����Ǹ� �ϱ� ���ؼ��� virtual ������� ��
        {

        }

        public void Func(int _val)
        {
            // �Լ� �����ε� Overloading
        }
    }

    public class Child : Parent
    {
        // Overriding
        public override void Func() //�θ� ���� ���� ������
        {

        }

        protected override void Start() 
        {
            this.Start(); //child�� Start ȣ��, this�� ���� ���ϹǷ� �����ص� �ȴٴ� ��
            base.Start(); //parent�� Start ȣ��
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
