using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Text t_count;
    public Image itemImage;

    public class DataItem
    {
        public string name { get; set; }
        public string context { get; set; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string type, string name)
    {
        StartCoroutine(GetItemInfo(type, name));
    }

    IEnumerator GetItemInfo(string type, string name)
    {
        //Debug.Log("type : " + type + ", name : " + name);
        string ItemURL = "http://127.0.0.1/getiteminfo.php";
            WWWForm form = new WWWForm();
        form.AddField("type", type);
        form.AddField("name", name);

        using (UnityWebRequest www =
            UnityWebRequest.Post(ItemURL, form))
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

                List<DataItem> dataScores =
                   JsonConvert.DeserializeObject<List<DataItem>>(data);

                foreach (DataItem dataScore in dataScores)
                {
                    Debug.Log(dataScore.name + " : " + dataScore.context);
                    itemImage.sprite = Resources.Load<Sprite>(dataScore.name);
                }
            }
        }
    }
}
