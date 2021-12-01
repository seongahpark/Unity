using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    //0.5초 간격으로 손 하나씩 다 나옴
    List<GameObject> Hand = new List<GameObject>();
    //Pooling으로 Hand 제어
    Queue<GameObject> HandPool = new Queue<GameObject>();

    static private int ranLength = 7;
    private int[] ranArr = Enumerable.Range(0, ranLength).ToArray();

    [SerializeField] private bool canShowHands = true;

    private void Awake()
    {
        GetHands();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShowHands) {
            MakeOrder();
            StartCoroutine(ShowHands()); 
        }

    }

    private void GetHands()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Hand.Add(this.transform.GetChild(i).gameObject);
        }
    }
    private void MakeOrder() //순서만 바꿔주고 순서에 해당하는 번호로 맵핑
    {
        for(int i=0; i<ranLength; i++)
        {
            int randIdx = Random.Range(i, ranLength);

            int tmp = ranArr[randIdx];
            ranArr[randIdx] = ranArr[i];
            ranArr[i] = tmp;
        }
    }

    IEnumerator ShowHands()
    {
        Debug.Log("show hands");
        canShowHands = false;
        for(int i=0; i<ranLength; i++)
        {
            int order = ranArr[i];
            Hand[order].SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1.0f);
        canShowHands = true;
    }
}
