using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHPBar : MonoBehaviour
{
    [SerializeField] Image[] HPbar = new Image[4];
    [SerializeField] private BossJinhillaControl bc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HP = bc.bossHp;
        switch (bc.page)
        {
            case 1:
                HPbar[0].fillAmount = (HP-1500) / 500f;
                break;
            case 2:
                HPbar[1].fillAmount = (HP-1000) / 500f;
                break;
            case 3:
                HPbar[2].fillAmount = (HP-500) / 500f;
                break;
            case 4:
                HPbar[3].fillAmount = HP / 500f;
                break;
        }
    }
}
