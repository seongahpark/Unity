using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] public GameObject targetGo = null;
    private float speed = 8f;
    private AttackRange atkRange = null; //AttackRange Ŭ������ �����
    
    private void Awake()
    {
        atkRange = GetComponent<AttackRange>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (targetGo == null) return; // Ÿ���� ���� �� ����

        if (atkRange.InAttackRange()) return; //��Ÿ� ���� ���������� �����̸� �ȵȴ�
        MoveToTarget();
    }

    private void MoveToTarget() //Ÿ���� ���� �̵�
    {
        Vector3 targetPos = targetGo.transform.position;
        Vector3 myPos = this.transform.position;
        Vector3 direction = targetPos - myPos;
        direction.Normalize(); //����ȭ
        transform.position =
            transform.position +
            (direction * speed * Time.deltaTime);
    }
}
