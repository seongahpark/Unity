using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;

    public void Fire()
    {
        GameObject bullet = Instantiate(
            bulletPrefab, transform.position, Quaternion.identity); //������� ȸ����
        //bullet.GetComponent<Bullet>().Shoot(transform.forward);
        //����ó���� ���� �ڵ� ����
        Bullet bulletComp = bullet.GetComponent<Bullet>();
        if (bulletComp) bulletComp.Shoot(transform.forward);
    }
}
