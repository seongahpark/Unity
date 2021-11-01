using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Slot : MonoBehaviour
{
    [SerializeField] private Item item;
    public int itemCount;
    [SerializeField] private Text t_count;

    public class DataItem
    {
        public string type { get; set; }
        public string name { get; set; }
        public int context { get; set; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item _item, int _cnt = 1)
    {
        item = _item;
        itemCount = _cnt;


    }
    private IEnumerator GetUserInfoCoroutine()
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/getinventory.php", ""))
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
                    Debug.Log(dataScore.name + " : " + dataScore.type);
                }
            }
        }
    }
}
