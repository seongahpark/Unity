using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    //state 인벤토리 타입, 0 : 무기, 1 : 아이템
    [SerializeField] private int state = 0;
    [SerializeField] private static bool invenctoryActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChkInventoryOpen();
    }

    private void ChkInventoryOpen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invenctoryActivated = !invenctoryActivated;
            if (invenctoryActivated) OpenInven();
            else CloseInven();
        }
    }

    private void OpenInven()
    {

    }
    private void CloseInven()
    {

    }
}
