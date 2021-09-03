using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [System.Serializable] //Serialize 해줘야만 유니티에서 구조체가 뜬다
    public struct SSample
    {
        [Range(0,10)] public int i;
        public float f;
    }

    public SSample sample = new SSample(); // 동적할당 해줘야 한다.

    public class CSample
    {
        public int i;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Call-by-value (값에 의한 호출)
        /*함수를 위해 별도의 임시공간이 생성된다. 함수 종료시 공간은 사라짐
         * 함수 호출시 전달되는 변수의 값을 복사하여 함수의 인자로 전달하기 때문에
         * local value의 특성을 가진다.
         * 즉, 함수 안에서 인자의 값이 변경되어도, 외부 변수의 값은 변경되지 않는다.
         */

        // Call by reference
        /*
        함수를 위해 별도의 임시공간이 생성되며, 종료시 공간이 사라진다.
        함수 호출시 인자로 전달되는 변수의 레퍼런스를 전달하므로, 해당 변수를 가리킨다.
        즉, 함수 안에서 인자의 값이 변경되면, argument로 전달된 객체의 값도 함께 변경된다.
         */

        CSample c = new CSample();
        c.i = 100;
        CSample d = c;
        d.i = 1;
        Debug.Log("c.i : " + c.i);
        Debug.Log("d.i : " + d.i);

        // new-delete
        // malloc - free

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Foo(Transform _tr)
    {
        //_tr.position.x = 1.0f; //이게 안됨, 바깥의 값에 영향을 주기 때문
        Debug.Log(_tr.position);
        //transform은 클래스
    }

    public void Func(Vector3 _pos)
    {
        //_pos.x = 1.0f; //바깥에 있는 값에 전혀 영향을 주지 않기 때문에 가능
        Debug.Log(_pos);
        //Vecotr는 구조체
    }
}
