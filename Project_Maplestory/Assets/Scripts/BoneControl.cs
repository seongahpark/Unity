using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneControl : MonoBehaviour
{
    List<GameObject> Bone = new List<GameObject>();
    private void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Bone.Add(this.transform.GetChild(i).gameObject);
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack1());
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3.7f);
    }

    IEnumerator attack1()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Bone[i].SetActive(false);
        }
        yield return new WaitForSeconds(1.5f);
        Bone[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Bone[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Bone[2].SetActive(true);
        Bone[3].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Bone[4].SetActive(true);
        Bone[5].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Bone[6].SetActive(true);
        Bone[7].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Bone[8].SetActive(true);
        Bone[9].SetActive(true);
    }
}
