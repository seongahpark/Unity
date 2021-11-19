using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation
{
    public int enemyHP;
    public int enemyScore;

    virtual public void hitEnemy()
    {
        enemyHP--;
    }

    virtual public bool hpChk()
    {
        if (enemyHP <= 0) return true;
        return false;
    }
}

public class Blue : EnemyInformation
{
    public override void hitEnemy()
    {
        base.hitEnemy();
    }

    public override bool hpChk()
    {
        return base.hpChk();
    }
}

public class Green : EnemyInformation
{
    public override void hitEnemy()
    {
        base.hitEnemy();
    }
    public override bool hpChk()
    {
        return base.hpChk();
    }
}

public class Purple : EnemyInformation
{
    public override void hitEnemy()
    {
        base.hitEnemy();
    }
    public override bool hpChk()
    {
        return base.hpChk();
    }

    public int randomScore()
    {
        int num = Random.Range(0, 2);
        if (num == 1) return 50;
        return 0;
    }
}

