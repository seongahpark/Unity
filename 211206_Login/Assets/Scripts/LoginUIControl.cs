using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIControl : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;
    public Button b_login;
    public Button b_register;
    // Start is called before the first frame update
    void Start()
    {
        LoginUI.SetActive(true);
        RegisterUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        b_login.onClick.AddListener(GoLoginBtnClick);
        b_register.onClick.AddListener(GoRegisterBtnClick);
    }
    private void GoRegisterBtnClick()
    {
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }

    private void GoLoginBtnClick()
    {
        LoginUI.SetActive(true);
        RegisterUI.SetActive(false);
    }
}
