using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ʈ �߰� ù ��° ��� - ��ũ��Ʈ �߰��� �ٷ� ����
[RequireComponent(typeof(Rigidbody))] 
//�� ��ũ��Ʈ�� �����ϱ� ���ؼ��� ������Ʈ�� ��û�Ѵ�, ���⼭�� Rigidbody ������Ʈ ��û
// -> ����Ƽ���� rigid body ������Ʈ�� �߰����� �ʾƵ� ��ũ��Ʈ �߰��� �ڵ����� ����´�
public class CollisionDetect : MonoBehaviour
{
    //������Ʈ �߰� �� ��° ��� - ����� AddComponent ȣ��� �߰���, ���� ������ ������
    private void Awake()
    {
        //GetComponent<BoxCollider>();
        gameObject.AddComponent<BoxCollider>();
    }
    // Callback Function -> �Լ��� ��������ִµ� �ý����� ������ Ÿ�ֿ̹� ȣ�����ִ� ��
    private void OnCollisionEnter(Collision _collision)
    {
        /*
        //Rigid Body
        �÷��̾�� �� �� ���� �ϳ��� rigid body�� ����������� �浹 ���� ����
         */
        Debug.Log("OnCollisionEnter");
        //LogWarning, LogError ���·� �ֿܼ� ��� �� ����
    }
}
