using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [System.Serializable] //Serialize ����߸� ����Ƽ���� ����ü�� ���
    public struct SSample
    {
        [Range(0,10)] public int i;
        public float f;
    }

    public SSample sample = new SSample(); // �����Ҵ� ����� �Ѵ�.

    public class CSample
    {
        public int i;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Call-by-value (���� ���� ȣ��)
        /*�Լ��� ���� ������ �ӽð����� �����ȴ�. �Լ� ����� ������ �����
         * �Լ� ȣ��� ���޵Ǵ� ������ ���� �����Ͽ� �Լ��� ���ڷ� �����ϱ� ������
         * local value�� Ư���� ������.
         * ��, �Լ� �ȿ��� ������ ���� ����Ǿ, �ܺ� ������ ���� ������� �ʴ´�.
         */

        // Call by reference
        /*
        �Լ��� ���� ������ �ӽð����� �����Ǹ�, ����� ������ �������.
        �Լ� ȣ��� ���ڷ� ���޵Ǵ� ������ ���۷����� �����ϹǷ�, �ش� ������ ����Ų��.
        ��, �Լ� �ȿ��� ������ ���� ����Ǹ�, argument�� ���޵� ��ü�� ���� �Բ� ����ȴ�.
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
        //_tr.position.x = 1.0f; //�̰� �ȵ�, �ٱ��� ���� ������ �ֱ� ����
        Debug.Log(_tr.position);
        //transform�� Ŭ����
    }

    public void Func(Vector3 _pos)
    {
        //_pos.x = 1.0f; //�ٱ��� �ִ� ���� ���� ������ ���� �ʱ� ������ ����
        Debug.Log(_pos);
        //Vecotr�� ����ü
    }
}
