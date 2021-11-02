using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;
    public InputField input_id;
    public InputField input_pw;
    public Button b_login;
    public Button b_register;
    public Text t_result;

    private string id;
    private string pw;

    private string LoginURL = "http://127.0.0.1/getuserinfo.php";
    // Start is called before the first frame update
    void Start()
    {
        t_result.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoginBtnClick()
    {
        id = input_id.text;
        pw = input_pw.text;
        StartCoroutine(GetUserInfo(id, pw));
    }

    private void GoRegisterBtnClick()
    {
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }
    IEnumerator GetUserInfo(string id, string pw)
    {
        //db에서 찾는거
        WWWForm form = new WWWForm();
        form.AddField("input_id", id);
        form.AddField("input_pw", pw);

        WWW www = new WWW(LoginURL, form);
        yield return www;

        t_result.gameObject.SetActive(true);
        t_result.text = www.text;
        Debug.Log(www.text);
    }
}
