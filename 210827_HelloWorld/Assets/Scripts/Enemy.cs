using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hp = 3;

    public void Damage(int _dmg = 1) //default �Ű�����
    {
        hp -= _dmg;
        if (hp == 0) Destroy(gameObject);
    }
}
