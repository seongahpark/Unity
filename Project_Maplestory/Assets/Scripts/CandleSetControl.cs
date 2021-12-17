using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSetControl : MonoBehaviour
{
    List<GameObject> candle = new List<GameObject>();
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject altar;
    private int candleCnt = 3; //default
    private int maxCandleCnt = 10;
    public bool altarOn = false;

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
        MakeAltar();
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
        if (flameCnt >= candleCnt) flameCnt = candleCnt;
        //candle[0].transform.GetChild(0);
        for(int i=0; i<flameCnt; i++)
        {
            GameObject flame = candle[i].transform.GetChild(0).gameObject;
            Animator flameAnim = flame.GetComponent<Animator>();
            flame.SetActive(true);
        }
    }

    private void MakeAltar()
    {
        //Debug.Log(flameCnt + ", " + candleCnt + ", " + altarOn);
        if(flameCnt >= candleCnt && !altarOn)
        {
            altarOn = true;
            //제단 범위 (-9.98~ 10.23, -1.48, 0)
            float randX = Random.Range(-9.98f, 10.23f);
            Vector3 pos = new Vector3(randX, -1.48f, 0);
            Instantiate(altar, pos, Quaternion.identity);
        }
    }

    public void ResetCandle()
    {
        altarOn = false;
        flameCnt = 0;
        for (int i = 0; i < candleCnt; i++)
        {
            GameObject flame = candle[i].transform.GetChild(0).gameObject;
            flame.SetActive(false);
        }
    }
}
