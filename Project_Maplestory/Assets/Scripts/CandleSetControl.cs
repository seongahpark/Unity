using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSetControl : MonoBehaviour
{
    List<GameObject> candle = new List<GameObject>();
    [SerializeField] private GameManager gm;
    private int candleCnt = 3; //default
    private int maxCandleCnt = 10;

    public int flameCnt = 0;
    private void Awake()
    {
        GetCandle();
    }
    // Start is called before the first frame update
    void Start()
    {
        ClearCandle();
        GetCandleCnt();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCandle();
        if(maxCandleCnt > flameCnt) GetFire();
    }

    private void GetCandle()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            candle.Add(this.transform.GetChild(i).gameObject);
        }
    }

    private void GetCandleCnt()
    {
        candleCnt = Mathf.CeilToInt(gm.playerCnt * 5.0f / 2.0f);
        Debug.Log(candleCnt);
    }

    private void ShowCandle()
    {
        for(int i=0; i<candleCnt; i++)
        {
            candle[i].gameObject.SetActive(true);
        }
    }

    private void ClearCandle()
    {
        for (int i = 0; i < maxCandleCnt; i++)
        {
            GameObject flame = candle[i].transform.GetChild(0).gameObject;
            candle[i].gameObject.SetActive(false);
            flame.SetActive(false);
        }
    }

    private void GetFire()
    {
        //candle[0].transform.GetChild(0);
        for(int i=0; i<flameCnt; i++)
        {
            GameObject flame = candle[i].transform.GetChild(0).gameObject;
            Animator flameAnim = flame.GetComponent<Animator>();
            flame.SetActive(true);
        }
    }
}
