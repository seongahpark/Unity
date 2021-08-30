using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir = Vector3.zero;
    private readonly float speed = 20f; //���� �б�����
    private bool isShoot = false;
    //private float elapsedTime = 0f; // ���� �ð�
    private readonly float lifeTime = 0.5f;// �Ѿ��� �����ϴ� �ð�, lifetime or duration 

    [SerializeField] private GameObject fxAtkPrefab = null;

    public void Shoot(Vector3 _dir)
    {
        dir = _dir;
        isShoot = true;

        Destroy(gameObject, lifeTime); //lifeTime �ð��� ���� �� �ı�
    }

    private void Update()
    {
        if (!isShoot) return;
        transform.position += (dir * speed * Time.deltaTime);

        //elapsedTime += Time.deltaTime;
        //if (elapsedTime >= lifeTime) Destroy(gameObject); //�Ѿ��� �߻���� 0.5�� ���Ŀ��� �ı�
    }

    //Enter, Stay, Exit
    private void OnTriggerEnter(Collider _col) // �Ű������� Collider �ΰ� ���
    {
        //Debug.Log("Trigger Enter : " + _col.name);
        // if(_col.tag == "Enemy") Destroy(gameObject);
        if (_col.CompareTag("Enemy")) // �� ����� �� ������
        {
            Debug.Log("Trigger Enter : " + _col.name);

            SpawnAttackEffect();

            // bullet�� �ı� O
            Destroy(gameObject);

            // ������ ������
            Enemy enemy = _col.GetComponent<Enemy>();
            enemy.Damage();
        }
    }

    private void SpawnAttackEffect()
    {
        Instantiate(fxAtkPrefab, transform.position, Quaternion.identity);
    }
}
