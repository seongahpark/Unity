using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    private readonly float interval = 1f;
    private GameObject targetGo = null;

    //property로 생성
    public GameObject TargetGo { set { targetGo = value; } }

    private void Awake() //Awake는 start 보다 먼저 호출
    {
        targetGo = GameObject.FindGameObjectWithTag("Player"); // 플레이어 태그를 갖고있는 오브젝트를 찾아줌
        //이 찾는 과정이 시간이 오래걸려 (문자열기반이기때문) 쓰지 않는걸 권장
        if (!targetGo) Debug.LogError("Player not found");
    }
    private void Start()
    {
        //Invoke("CreateEnemy", interval);
        InvokeRepeating("CreateEnemy", interval, interval); // 메소드가 계속 반복되도록 실행해줌
        //메소드, 초기 시작시간, 반복할 주기
    }

    private void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        //적은 Y축 고정
        float posX = Random.Range(-25f, 25f);
        float posZ = Random.Range(-25f, 25f);
        Vector3 pos = new Vector3(posX, 0f, posZ); // 동적 할당을 하는데 해제를 안한다
        //c#은 메모리를 delete를 할 필요가 없다
        enemy.transform.position = pos;

        enemy.GetComponent<Follow>().targetGo = targetGo;
        enemy.GetComponent<AttackRange>().SetTargetGo(targetGo);
    }

}
