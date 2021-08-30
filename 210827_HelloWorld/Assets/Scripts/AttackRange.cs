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
        if (!targetGo) return; //타겟이 없으면 리턴
        if (InAttackRange()) Debug.Log("Attack!");
    }

    public bool InAttackRange() //사거리 내로 들어왔는지 확인하는 함수
    {
        float dist = Vector3.Distance(targetGo.transform.position, this.transform.position);
        //타겟과 나의 거리를 측정
        return dist < atkRange;
    }

    public void SetTargetGo(GameObject _targetGo)
    {
        targetGo = _targetGo;
    }
}
