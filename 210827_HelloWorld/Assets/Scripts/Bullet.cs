using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir = Vector3.zero;
    private readonly float speed = 20f; //변수 읽기전용
    private bool isShoot = false;
    //private float elapsedTime = 0f; // 누적 시간
    private readonly float lifeTime = 0.5f;// 총알이 존재하는 시간, lifetime or duration 

    [SerializeField] private GameObject fxAtkPrefab = null;

    public void Shoot(Vector3 _dir)
    {
        dir = _dir;
        isShoot = true;

        Destroy(gameObject, lifeTime); //lifeTime 시간이 지난 후 파괴
    }

    private void Update()
    {
        if (!isShoot) return;
        transform.position += (dir * speed * Time.deltaTime);

        //elapsedTime += Time.deltaTime;
        //if (elapsedTime >= lifeTime) Destroy(gameObject); //총알이 발사된지 0.5초 이후에는 파괴
    }

    //Enter, Stay, Exit
    private void OnTriggerEnter(Collider _col) // 매개변수가 Collider 인거 기억
    {
        //Debug.Log("Trigger Enter : " + _col.name);
        // if(_col.tag == "Enemy") Destroy(gameObject);
        if (_col.CompareTag("Enemy")) // 이 방법이 더 빠르다
        {
            Debug.Log("Trigger Enter : " + _col.name);

            SpawnAttackEffect();

            // bullet은 파괴 O
            Destroy(gameObject);

            // 적에게 데미지
            Enemy enemy = _col.GetComponent<Enemy>();
            enemy.Damage();
        }
    }

    private void SpawnAttackEffect()
    {
        Instantiate(fxAtkPrefab, transform.position, Quaternion.identity);
    }
}
