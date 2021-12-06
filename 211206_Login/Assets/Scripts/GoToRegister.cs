using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRegister : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GoRegisterBtnClick()
    {
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }
}
