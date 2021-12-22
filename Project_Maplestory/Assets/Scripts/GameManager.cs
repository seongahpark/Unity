using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] BossJinhillaControl bc;
    [SerializeField] DeathCountContrl dc;
    [SerializeField] CandleSetControl csc;

    public int playerCnt = 1; // default
    [SerializeField] Text time;
    public static float setTime = 1784; // 29�� 44�к��� �����ϴ� �� �ݿ�
    public int min = 30;
    public float sec = 60;

    //�� ���� �ð� �ֱ�
    public int page_cutting = 0;
    public static int[] cutTime = { 150, 125, 100 };
    private float nextCutTime;
    public bool isCutting = false;

    [SerializeField] GameObject failObj;
    [SerializeField] Transform failObjPos;
    [SerializeField] GameObject cutMotion;

    // Start is called before the first frame update
    void Start()
    {
        //���� �� ���� �ð� -> 27 : 14
        nextCutTime = setTime - cutTime[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError("set, next : " + setTime + ", " + nextCutTime);
        SetTimer();
        ChkCutTime();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            setTime = 1640;
            //GameOver();
        }
    }

    private void ChkCutTime()
    {
        if(setTime <= nextCutTime)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.z = 10;
            //�� ���� ������ ������ �� �÷��̾� ��� ����
            //�� ���� ��� �÷��̾� ȭ�鿡 �������� ���
            Instantiate(cutMotion, pos, Quaternion.identity);
            bc.ChkCutPage();
            GetNextCutTime();
            isCutting = true;
            Invoke("SetIsCuttingFalse", 3.6f);

            //����ī��Ʈ �ʱ�ȭ
            dc.RedBreak();
            dc.GetDeathCount();

            //�к� �ʱ�ȭ
            csc.AfterCutting();
        }
    }

    private void SetIsCuttingFalse()
    {
        isCutting = false;
    }
    public void GetNextCutTime()
    {
        switch (page_cutting)
        {
            case 0:
                nextCutTime -= cutTime[0];
                break;
            case 1:
                nextCutTime -= cutTime[1];
                break;                                                                                      
            case 2:
                nextCutTime -= cutTime[2];
                break;
        }
        Debug.Log("next cut : " + nextCutTime);
    }
    private void GameOver()
    {
        Vector3 pos = failObjPos.position;
        pos.y += 1.5f;
        pos.z = 10f;
        Instantiate(failObj, pos, transform.rotation);
    }

    private void SetTimer()
    {
        setTime -= Time.deltaTime;
        if (setTime >= 60f)
        {
            min = (int)setTime / 60;
            sec = setTime % 60;

            if (sec < 10f)
            {
                time.text = "<color=yellow>" + min + "</color>" +
                    "<size=50>��</size> " + "<color=yellow>0" + (int)sec + "</color><size=50>��</size>";
            }
            else time.text = "<color=yellow>" + min + "</color>" +
                "<size=50>��</size> " + "<color=yellow>" + (int)sec + "</color><size=50>��</size>";
        }

        if (setTime < 60f)
        {
            if (sec < 10f) time.text = "<color=yellow>00</color>" + "<size=50>��</size> " + "<color=yellow>0" + (int)setTime + "</color><size=50>��</size>";
            time.text = "<color=yellow>00</color>" + "<size=50>��</size> " + "<color=yellow>" + (int)setTime + "</color><size=50>��</size>";
        }

        if (setTime <= 0)
        {
            time.text = "<color=yellow>00</color><size=50>��</size> <color=yellow>00</color><size=50>��</size>";
        }
    }
}
