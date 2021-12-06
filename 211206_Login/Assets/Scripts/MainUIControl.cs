using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIControl : MonoBehaviour
{
    public GameObject ModiUI;
    public GameObject LogoutUI;
    public GameObject WithdrawUI;
    public Text T_welcome;

    // Start is called before the first frame update
    void Start()
    {
        ModiUI.SetActive(false);
        LogoutUI.SetActive(false);
        WithdrawUI.SetActive(false);

        T_welcome.text = "Welcome " + UserInfo.id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModiBtnOnClick()
    {
        ModiUI.SetActive(true);
    }
    public void ModiBtnOffClick()
    {
        ModiUI.SetActive(false);
    }
    public void LogoutBtnOnClick()
    {
        LogoutUI.SetActive(true);
    }
    public void LogoutBtnOffClick()
    {
        LogoutUI.SetActive(false);
    }

    public void Logout()
    {
        SceneManager.LoadScene("Login");
    }
    public void WithdrawaBtnOnClick()
    {
        WithdrawUI.SetActive(true);
    }
    public void WithdrawaBtnOffClick()
    {
        WithdrawUI.SetActive(false);
    }
}
