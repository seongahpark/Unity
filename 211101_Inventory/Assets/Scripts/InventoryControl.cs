using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    //state 인벤토리 타입, 0 : 무기, 1 : 아이템
    [SerializeField] private int state = 0;
    [SerializeField] private static bool invenctoryActivated = false;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slotParent; //grid setting
    public string type = "weapon"; //default값

    private Slot[] slots; // 슬롯 배열

    private string InventoryURL = "http://127.0.0.1/getinventory.php";
    // Start is called before the first frame update
    public class DataItem
    {
        public string name { get; set; }
        //public int context { get; set; }
    }
    void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        ChkInventoryOpen();
        //StartCoroutine(GetInventoryInfo("weapon"));
    }

    private void ChkInventoryOpen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invenctoryActivated = !invenctoryActivated;
        }
        if (invenctoryActivated) OpenInven();
        else CloseInven();
    }

    private void OpenInven()
    {
        inventory.SetActive(true);
        StartCoroutine(GetInventoryInfo(type));
    }
    private void CloseInven()
    {
        inventory.SetActive(false);
    }

    public void ClickBtn()
    {
        cleanInven();
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;
        type = clickBtn.GetComponentInChildren<Text>().text.ToLower();
        StartCoroutine(GetInventoryInfo(type));
    }

    private void cleanInven()
    {
        for(int i=0; i<slots.Length; i++)
        {
            slots[i].itemImage.sprite = null;
        }
    }
    private void ShowItems(string name, int index)
    {
        if(!slots[index].itemImage.sprite)
        {
            slots[index].AddItem(type, name);
            return;
        }
    }
    IEnumerator GetInventoryInfo(string type)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", type);

        using (UnityWebRequest www =
            UnityWebRequest.Post(InventoryURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

                List<DataItem> dataScores =
                   JsonConvert.DeserializeObject<List<DataItem>>(data);

                foreach (DataItem dataScore in dataScores)
                {
                    //Debug.Log(dataScore.name);
                    int index = dataScores.IndexOf(dataScore);
                    ShowItems(dataScore.name, index);
                }
            }
        }
    }
}
