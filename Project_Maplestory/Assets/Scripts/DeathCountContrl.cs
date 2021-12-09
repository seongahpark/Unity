using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCountContrl : MonoBehaviour
{
    List<GameObject> deathCount = new List<GameObject>();
    [SerializeField] DeathCountPerControl[] dpc = new DeathCountPerControl[5];

    bool[] deathChk = new bool[5];
    public int redCnt = 0;
    public int deathCnt = 5; //√ ±‚
    // Start is called before the first frame update
    void Start()
    {
        GetDeathCount();
    }

    // Update is called once per frame
    void Update()
    {
        ChkDeathCount();
    }

    private void GetDeathCount()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            deathCount.Add(this.transform.GetChild(i).gameObject);
            deathChk[i] = true;
        }
    }

    public void ChkDeathCount()
    {
        Debug.Log("redCnt : " + redCnt + " / " + deathChk[0] + deathChk[1]
            + deathChk[2] + deathChk[3] + deathChk[4]);
        for(int i=0; i< deathCnt; i++)
        {
            if (redCnt > i) deathChk[i] = true;
            else deathChk[i] = false;
        }
    }
    public void DCWhiteToRed()
    {
        ChkDeathCount();
        for (int i=0; i< deathCnt; i++)
        {
            if(deathChk[i] == true)
            {
                dpc[i].WhiteToRed();
            }
        }
    }

    public void DCRedToWhite()
    {
        for (int i = 0; i < deathCnt; i++)
        {
            if (deathChk[i] == false) dpc[i].RedToWhite();
        }
    }
}
