using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modify : MonoBehaviour
{
    public InputField pw_current;
    public InputField pw_new;
    public InputField pw_newConfirm;

    public Text t_result;

    private bool isCorrect = false;
    private bool canModi = false;

    private string ModiURL = "http://127.0.0.1/modiuserinfo.php";
    // Start is called before the first frame update
    void Start()
    {
        t_result.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChkCurrentPw()
    {
        Debug.Log(UserInfo.id + ", " + UserInfo.pw);
        if (pw_current.text != UserInfo.pw)
        {
            t_result.text = "Password do not match";
            isCorrect = false;
        }
        else
        {
            t_result.text = "";
            isCorrect = true;
        }
    }
    public void ChkNewPw()
    {
        if(pw_current.text != "" && pw_current.text == pw_new.text)
        {
            canModi = false;
            t_result.text = "It's same as Current Password";
        }
        else if(pw_new.text != pw_newConfirm.text)
        {
            canModi = false;
            t_result.text = "It's different from the confirm password.";
        }
        else if (isCorrect && pw_current.text != pw_new.text && pw_new.text == pw_newConfirm.text) { 
            canModi = true;
            t_result.text = "Can Modify. Press Modify Button";
        }
    }

    public void onClickModi()
    {
        ChkNewPw();
        StartCoroutine(ModiUserInfo());
    }
    IEnumerator ModiUserInfo()
    {
        //db에서 찾는거
        WWWForm form = new WWWForm();
        form.AddField("id", UserInfo.id);
        form.AddField("pw", pw_new.text);

        WWW www = new WWW(ModiURL, form);
        yield return www;

        Debug.Log(www.text);
        t_result.text = www.text;

        if(www.text == "Password Modify Success")
        {
            UserInfo.pw = pw_new.text;
        }
    }
}
