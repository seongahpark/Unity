using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private float atkRange = 2f;
    [SerializeField] private GameObject targetGo = null;

    // Update is called once per frame
    void Update()
    {
        if (!targetGo) return; //Ÿ���� ������ ����
        if (InAttackRange()) Debug.Log("Attack!");
    }

    public bool InAttackRange() //��Ÿ� ���� ���Դ��� Ȯ���ϴ� �Լ�
    {
        float dist = Vector3.Distance(targetGo.transform.position, this.transform.position);
        //Ÿ�ٰ� ���� �Ÿ��� ����
        return dist < atkRange;
    }

    public void SetTargetGo(GameObject _targetGo)
    {
        targetGo = _targetGo;
    }
}
