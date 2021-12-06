using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Withdraw : MonoBehaviour
{
    public Text T_withdraw;
    private string DeleteURL = "http://127.0.0.1/deleteuserinfo.php";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickWithdraw()
    {
        StartCoroutine(DeleteUserInfo());
    }
    IEnumerator DeleteUserInfo()
    {
        //db에서 찾는거
        WWWForm form = new WWWForm();
        form.AddField("id", UserInfo.id);

        WWW www = new WWW(DeleteURL, form);
        yield return www;

        Debug.Log(www.text);
        T_withdraw.text = www.text;

        if(www.text != "Failed to withdraw")
        {
            StartCoroutine(waitForWithdraw());
        }
    }

    IEnumerator waitForWithdraw()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Login");
    }
}
