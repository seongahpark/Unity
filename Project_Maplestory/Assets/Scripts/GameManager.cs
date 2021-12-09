using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerCnt = 1; // default
    [SerializeField] Text time;
    public float setTime = 1800;
    public int min = 30;
    public float sec = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();
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
                    "<size=50>분</size> " + "<color=yellow>0" + (int)sec + "</color><size=50>초</size>";
            }
            else time.text = "<color=yellow>" + min + "</color>" +
                "<size=50>분</size> " + "<color=yellow>" + (int)sec + "</color><size=50>초</size>";
        }

        if (setTime < 60f)
        {
            if (sec < 10f) time.text = "<color=yellow>00</color>" + "<size=50>분</size> " + "<color=yellow>0" + (int)setTime + "</color><size=50>초</size>";
            time.text = "<color=yellow>00</color>" + "<size=50>분</size> " + "<color=yellow>" + (int)setTime + "</color><size=50>초</size>";
        }

        if (setTime <= 0)
        {
            time.text = "<color=yellow>00</color><size=50>분</size> <color=yellow>00</color><size=50>초</size>";
        }
    }
}
