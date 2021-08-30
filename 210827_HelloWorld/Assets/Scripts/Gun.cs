using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;

    public void Fire()
    {
        GameObject bullet = Instantiate(
            bulletPrefab, transform.position, Quaternion.identity); //사원수로 회전값
        //bullet.GetComponent<Bullet>().Shoot(transform.forward);
        //예외처리를 위해 코드 수정
        Bullet bulletComp = bullet.GetComponent<Bullet>();
        if (bulletComp) bulletComp.Shoot(transform.forward);
    }
}
