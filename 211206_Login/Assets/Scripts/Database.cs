using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;


public class Database : MonoBehaviour
{
    public class DataUserInfo
    {
        public string id { get; set; }
        public string pw { get; set; }
        public int age { get; set; }
        public string name { get; set; }
    }


    void Start()
    {
        //StartCoroutine(AddUserInfoCoroutine("kch1234", "1234", 28, "È£¾ß"));
        //StartCoroutine(GetUserInfoCoroutine());
    }

    private IEnumerator AddUserInfoCoroutine(
        string _id, string _pw, int _age, string _name)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        form.AddField("pw", _pw);
        form.AddField("age", _age);
        form.AddField("name", _name);

        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/adduserinfo.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
        }

        Debug.Log("AddUserInfo Success : " + _id);
    }

    private IEnumerator GetUserInfoCoroutine()
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/getuserinfo.php", ""))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

                List<DataUserInfo> dataScores =
                   JsonConvert.DeserializeObject<List<DataUserInfo>>(data);

                foreach (DataUserInfo dataScore in dataScores)
                {
                    Debug.Log(dataScore.id + " : " + dataScore.pw);
                }
            }
        }
    }
}