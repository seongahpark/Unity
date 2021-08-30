using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    private readonly float interval = 1f;
    private GameObject targetGo = null;

    //property�� ����
    public GameObject TargetGo { set { targetGo = value; } }

    private void Awake() //Awake�� start ���� ���� ȣ��
    {
        targetGo = GameObject.FindGameObjectWithTag("Player"); // �÷��̾� �±׸� �����ִ� ������Ʈ�� ã����
        //�� ã�� ������ �ð��� �����ɷ� (���ڿ�����̱⶧��) ���� �ʴ°� ����
        if (!targetGo) Debug.LogError("Player not found");
    }
    private void Start()
    {
        //Invoke("CreateEnemy", interval);
        InvokeRepeating("CreateEnemy", interval, interval); // �޼ҵ尡 ��� �ݺ��ǵ��� ��������
        //�޼ҵ�, �ʱ� ���۽ð�, �ݺ��� �ֱ�
    }

    private void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        //���� Y�� ����
        float posX = Random.Range(-25f, 25f);
        float posZ = Random.Range(-25f, 25f);
        Vector3 pos = new Vector3(posX, 0f, posZ); // ���� �Ҵ��� �ϴµ� ������ ���Ѵ�
        //c#�� �޸𸮸� delete�� �� �ʿ䰡 ����
        enemy.transform.position = pos;

        enemy.GetComponent<Follow>().targetGo = targetGo;
        enemy.GetComponent<AttackRange>().SetTargetGo(targetGo);
    }

}
