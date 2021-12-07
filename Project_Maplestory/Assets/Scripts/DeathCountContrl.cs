using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCountContrl : MonoBehaviour
{
    List<GameObject> deathCount = new List<GameObject>();
    bool[] deathChk = new bool[5];
    public int redCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetDeathCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetDeathCount()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            deathCount.Add(this.transform.GetChild(i).gameObject);
            deathChk[i] = true;
        }
    }
}
