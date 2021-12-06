using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField input_id;
    public InputField input_pw;
    public InputField input_name;
    public InputField input_age;
    [SerializeField] private Button b_register;
    [SerializeField] private Text t_result;

    private string RegisterURL = "http://127.0.0.1/adduserinfo.php";
    // Start is called before the first frame update
    void Start()
    {
        t_result.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RegisterBtnClick()
    {
        string id = input_id.text;
        string pw = input_pw.text;
        string name = input_name.text;
        string age = input_age.text;
        StartCoroutine(AddUserInfo(id, pw, name, age));
    }
    IEnumerator AddUserInfo(string id, string pw, string name, string age)
    {
        //db에서 찾는거
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("pw", pw);
        form.AddField("name", name);
        form.AddField("age", age);

        WWW www = new WWW(RegisterURL, form);
        yield return www;

        t_result.gameObject.SetActive(true);
        t_result.text = www.text;
        Debug.Log(www.text);
    }
}
