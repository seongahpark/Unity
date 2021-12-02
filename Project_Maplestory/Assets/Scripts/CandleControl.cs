using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleControl : MonoBehaviour
{
    private GameObject flameObj = null;
    private GameObject candleObj = null;
    // Start is called before the first frame update
    void Start()
    {
        flameObj = transform.GetChild(0).gameObject;
        candleObj = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
