using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] public GameObject targetGo = null;
    private float speed = 8f;
    private AttackRange atkRange = null; //AttackRange 클래스를 갖고옴
    
    private void Awake()
    {
        atkRange = GetComponent<AttackRange>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (targetGo == null) return; // 타겟이 없을 때 리턴

        if (atkRange.InAttackRange()) return; //사거리 내에 들어와있으면 움직이면 안된다
        MoveToTarget();
    }

    private void MoveToTarget() //타켓을 향해 이동
    {
        Vector3 targetPos = targetGo.transform.position;
        Vector3 myPos = this.transform.position;
        Vector3 direction = targetPos - myPos;
        direction.Normalize(); //정규화
        transform.position =
            transform.position +
            (direction * speed * Time.deltaTime);
    }
}
